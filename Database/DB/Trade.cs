//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Trade
    {
        public int ID { get; set; }
        public string BuyOrSell { get; set; }
        public int Quantity { get; set; }
        public double PriceTradedAt { get; set; }
        public System.DateTime TradeDate { get; set; }
        public int InstrumentID { get; set; }
        public double MarkToMarket { get; set; }
        public double PnL { get; set; }
        public double Delta { get; set; }
        public double Gamma { get; set; }
        public double Vega { get; set; }
        public double Theta { get; set; }
        public double Rho { get; set; }
    
        public virtual Instrument Instrument { get; set; }
    }
}
