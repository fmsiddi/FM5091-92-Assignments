function [IV, iterations] = Bisection(type,S,K,r,T,E,obsPrice)

%INPUT A VECTOR FOR EACH INPUT

%INITIALIZE
low_bound = ones(size(obsPrice)).* 0.001;
high_bound = ones(size(obsPrice)).*10;
guessVol = (high_bound + low_bound)./2;
BSPrice = zeros(size(obsPrice));

%d1 and d2 are parameters that are used throughout the B-S model, they are
%defined here as a function of the stock price(S), strike price(K),
%interest rate(r), volatility(vol), and maturity(T)
d1 = @(S,K,r,guessVol,T) (log(S./K) + ((r+(guessVol.^2)./2).*T) / (guessVol.*sqrt(T)));
d2 = @(S,K,r,guessVol,T) d1(S,K,r,guessVol,T) - (guessVol.*sqrt(T));

%C and P produce the call option price and put option price respectively.
%They are functions of the stock price(S), strike price(K),
%interest rate(r), volatility(vol), and maturity(T)
C = @(S,K,r,guessVol,T) S.*normcdf(d1(S,K,r,guessVol,T)) - K.*exp(-r.*T).*normcdf(d2(S,K,r,guessVol,T));
P = @(S,K,r,guessVol,T) K.*exp(-r.*T).*normcdf(-d2(S,K,r,guessVol,T)) - S.*normcdf(-d1(S,K,r,guessVol,T));


%type = 1 means call
%type = 0 means put
type = (type == 1);

BSPrice(type) = C(S(type),K(type),r(type),guessVol(type),T(type));
BSPrice(~type) = P(S(~type),K(~type),r(~type),guessVol(~type),T(~type));

iterations = 0;


while any(abs(BSPrice - obsPrice) > E)
    low_bound(BSPrice <= obsPrice) = guessVol(BSPrice <= obsPrice);
    high_bound(BSPrice > obsPrice) = guessVol(BSPrice > obsPrice);
    guessVol = (high_bound + low_bound)/2;
    iterations = iterations + 1;
    BSPrice(type) = C(S(type),K(type),r(type),guessVol(type),T(type));
    BSPrice(~type) = P(S(~type),K(~type),r(~type),guessVol(~type),T(~type));
    if (iterations > 50) 
        break;
    end
end

IV = guessVol;

disp(IV)
disp(iterations)