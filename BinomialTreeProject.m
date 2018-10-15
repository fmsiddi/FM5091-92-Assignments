function [price, delta, gamma, theta, vega, rho] = BinomialTreeProject(type,S0,K,r,q,T,vol,N)
%Price and 3 greeks are provided by PriceAnd3Greeks, the remaining two
%greeks are calculated with VegaRho in a separate function to avoid
%infinite recursion. 

%The "type" variable is as follows: 
%1 = Euro Call 
%2 = Euro Put 
%3 = American Call 
%4 = American Put
    [price, delta, gamma, theta] = PriceAnd3Greeks(type,S0,K,r,q,T,vol,N);
    [vega, rho] = VegaRho(type,S0,K,r,q,T,vol,N);
    
    fprintf("Price: %f\n", price)
    fprintf("Delta: %f\n", delta)
    fprintf("Gamma: %f\n", gamma)
    fprintf("Theta: %f\n", theta)
    fprintf("Vega: %f\n", vega)
    fprintf("Rho: %f\n", rho)
end

function [price, delta, gamma, theta] = PriceAnd3Greeks(type,S0,K,r,q,T,vol,N)
deltaT = T/N; %timestep
u = exp(vol * sqrt(deltaT)); %factor by which stock increases by timestep
d = 1/u; %factor by which stock decreases by timestep
p = (exp((r-q)*deltaT) - d) / (u-d); %probability of up-tick
discount = exp(-(r-q) * deltaT); %discount factor per timestep
p_u = discount * p; %combining p and disc to make code more concise
p_d = discount * (1-p); %combining p and disc to make code more concise
SVals = zeros(N+1, N+1); %initializing stock price lattice
OVals = zeros(N+1, N+1); %initializing option price lattice
SVals(1, 1) = S0; %set initial stock price

%Setup all possible stock prices
for i = 2:(N+1)
    for j = 1:i
        SVals(i,j) = S0*(d^(i-1))*(u^(2*(j-1)));
    end
end

%Calculate the option price at the final timestep of the tree
for j = 1:N+1
    if (type == 1)||(type == 3)
        OVals(N+1, j) = max(SVals(N+1, j) - K,0);
    elseif (type == 2)||(type == 4)
        OVals(N+1, j) = max(K - SVals(N+1, j), 0);
    else
        error("incorrect type");
    end
end

%Working backwards from the terminal option prices to get the initial
%option price
for i = N:-1:1
    for j = 1:i
        if (type == 1)||(type == 2) %Euro Call or Put
            OVals(i,j) = p_u*OVals(i+1,j+1) + p_d*OVals(i+1,j);
        elseif (type == 3)||(type == 4)
            OVals(i,j) = p_u*OVals(i+1,j+1) + p_d*OVals(i+1,j);
            if type == 3 %American Call
                OVals(i,j) = max(OVals(i,j), SVals(i,j) - K);
            elseif type == 4 %American Put
                OVals(i,j) = max(OVals(i,j), K - SVals(i,j));
            end
        end
    end
end
      
price = OVals(1,1);
delta = (OVals(2,2) - OVals(2,1)) / (SVals(2,2) - SVals(2,1));
gamma = (((OVals(3,3) - OVals(3,2)) / (SVals(3,3) - SVals(3,2))) - (OVals(3,2) - OVals(3,1)) / (SVals(3,2) - SVals(3,1)))/(.5*(SVals(3,3) - SVals(3,1)));
theta = (OVals(3,2) - OVals(1,1))/(2*(T/N));

end

function [vega, rho] = VegaRho(type,S0,K,r,q,T,vol,N)
%Bumps either volatlity or the interest rate by a basis point then applies
%the formula for the appropriate greek.

vega = (PriceAnd3Greeks(type,S0,K,r,q,T,(vol*1.0001),N) - PriceAnd3Greeks(type,S0,K,r,q,T,(vol*0.9999),N))/(0.0002*vol);
rho = (PriceAnd3Greeks(type,S0,K,(r*1.0001),q,T,vol,N) - PriceAnd3Greeks(type,S0,K,(r*0.9999),q,T,vol,N))/(0.0002*r);

end