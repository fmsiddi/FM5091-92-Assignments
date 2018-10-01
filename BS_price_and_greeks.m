
%d1 and d2 are parameters that are used throughout the B-S model, they are
%defined here as a function of the stock price(S), strike price(K),
%interest rate(r), volatility(vol), and maturity(T)
d1 = @(S,K,r,vol,T) (log(S/K) + (r+(vol^2)/2)*T) / (vol*sqrt(T));
d2 = @(S,K,r,vol,T) d1(S,K,r,vol,T) - (vol*sqrt(T));

%C and P produce the call option price and put option price respectively.
%They are functions of the stock price(S), strike price(K),
%interest rate(r), volatility(vol), and maturity(T)
C = @(S,K,r,vol,T) S*normcdf(d1(S,K,r,vol,T)) - K*exp(-r*T)*normcdf(d2(S,K,r,vol,T));
P = @(S,K,r,vol,T) K*exp(-r*T)*normcdf(-d2(S,K,r,vol,T)) - S*normcdf(-d1(S,K,r,vol,T));

%CD and PD are the call option delta and put option delta respectively.
%They measure the sensitivity of the option price to a change in the
%underlying stock price and are functions of the stock price(S), strike price(K),
%interest rate(r), volatility(vol), and maturity(T)
CD = @(S,K,r,vol,T) normcdf(d1(S,K,r,vol,T));
PD = @(S,K,r,vol,T) normcdf(d1(S,K,r,vol,T))-1;

%G is the option gamma. It measures the convexity of the option's price
%with respect to a change in the underlying stock price (or the sensitivity
%of the option price to change in the option's delta.) It is a function of the stock price(S), strike price(K),
%interest rate(r), volatility(vol), and maturity(T)
G = @(S,K,r,vol,T) normpdf(d1(S,K,r,vol,T)) / (S*vol*sqrt(T));

%V is the option vega. It measures the option price's sensitivity to a change in
%volatility. It is a function of the stock price(S), strike price(K),
%interest rate(r), volatility(vol), and maturity(T)
V = @(S,K,r,vol,T) S*normpdf(d1(S,K,r,vol,T))*sqrt(T);

%CT and PT are the call option's theta and put option's theta respectively.
%They measure the option price's sensitivity to a change in maturity. They
%are functions of the stock price(S), strike price(K),
%interest rate(r), volatility(vol), and maturity(T)
CT = @(S,K,r,vol,T) (-S*normpdf(d1(S,K,r,vol,T))*vol)/(2*sqrt(T)) - r*K*exp(-r*T)*normcdf(d2(S,K,r,vol,T));
PT = @(S,K,r,vol,T) (-S*normpdf(d1(S,K,r,vol,T))*vol)/(2*sqrt(T)) + r*K*exp(-r*T)*normcdf(-d2(S,K,r,vol,T));

%CR and PR are the call option's rho and put option's rho respectively.
%They measure the option price's senstivity to change in interest rate.
%They are functions of the stock price(S), strike price(K),
%interest rate(r), volatility(vol), and maturity(T)
CR = @(S,K,r,vol,T) K*T*exp(-r*T)*normcdf(d2(S,K,r,vol,T));
PR = @(S,K,r,vol,T) -K*T*exp(-r*T)*normcdf(-d2(S,K,r,vol,T));