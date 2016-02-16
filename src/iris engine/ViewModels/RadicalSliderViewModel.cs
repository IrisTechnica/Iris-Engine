using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace iris_engine.ViewModels
{
    public class RadicalSliderViewModel : AbstractModelBase
    {
        #region Internal Data Members

        private double strokeThickness = 2;

        private double value = 0;

        private double maxValue = 100;

        private double minValue = 0;

        private bool isLargeArcFlg = false;

        #endregion

        #region Public Properties

        public double StrokeThickness
        {
            get
            {
                return strokeThickness;
            }

            set
            {
                strokeThickness = value;
            }
        }

        public double Value
        {
            get
            {
                return value;
            }

            set
            {
                var temp = value;
                if (maxValue < temp) temp = maxValue;
                if (minValue > temp) temp = minValue;
                this.SetProperty(ref this.value, temp);
            }
        }

        public double Percentage
        {
            get
            {
                return (Value - MinValue) / (MaxValue - MinValue);
            }
        }

        public bool IsLargeArcFlg
        {
            get
            {
                return isLargeArcFlg;
            }

            set
            {
                isLargeArcFlg = value;
            }
        }

        public double MaxValue
        {
            get
            {
                return maxValue;
            }

            set
            {
                this.SetProperty(ref maxValue, value);
            }
        }

        public double MinValue
        {
            get
            {
                return minValue;
            }

            set
            {
                this.SetProperty(ref minValue, value);
            }
        }

        #endregion

    }
}
