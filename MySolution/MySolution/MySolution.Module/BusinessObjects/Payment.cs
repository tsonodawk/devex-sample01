using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace MySolution.Module.BusinessObjects
{
    [DefaultClassOptions, ImageName("BO_SaleItem")]
    public class Payment : BaseObject
    {
        public Payment(Session session) : base(session) { }
        private double rate;
        public double Rate
        {
            get
            {
                return rate;
            }
            set
            {
                if (SetPropertyValue(nameof(Rate), ref rate, value))
                    OnChanged(nameof(Amount));
            }
        }
        private double hours;
        [ImmediatePostData(true)]
        public double Hours
        {
            get
            {
                return hours;
            }
            set
            {
                if (SetPropertyValue(nameof(Hours), ref hours, value))
                    OnChanged(nameof(Amount));
            }
        }
        [PersistentAlias("Rate * Hours")]
        public double Amount
        {
            get
            {
                object tempObject = EvaluateAlias(nameof(Amount));
                if (tempObject != null)
                {
                    return (double)tempObject;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}