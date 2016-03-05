using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NetworkModel
{
    public class UVNodeViewModel : AbstractNodeViewModel
    {
        #region Internal Classes [None Internal constraints]

        public class InternalOutputs
        {
            private FloatConnectorViewModel uvX;

            private FloatConnectorViewModel uvY;

            public FloatConnectorViewModel UvX
            {
                get
                {
                    if (uvX == null) uvX = new FloatConnectorViewModel("X");
                    return uvX;
                }

                set
                {
                    uvX = value;
                }
            }

            public FloatConnectorViewModel UvY
            {
                get
                {
                    if (uvY == null) uvY = new FloatConnectorViewModel("Y");
                    return uvY;
                }

                set
                {
                    uvY = value;
                }
            }
        }

        #endregion

        #region Private Data Members

        private InternalOutputs outputs = new InternalOutputs();

        private byte[] pixelEntity = null;

        #endregion

        #region Private Methods

        private void Initialize()
        {
            this.HasImage = true;
            this.OutputConnectors.Add(outputs.UvX);
            this.OutputConnectors.Add(outputs.UvY);
            CreateUVImage();
        }

        private void CreateUVImage()
        {
            this.Bitmap.Lock();

            var rect = new Int32Rect(0, 0, Bitmap.PixelWidth, Bitmap.PixelHeight);
            var bytesPerPixel = (Bitmap.Format.BitsPerPixel + 7) / 8; // 1 ピクセル当たりのバイト数（4 になるはず）
            var stride = Bitmap.PixelWidth * bytesPerPixel; // 幅方向のバイト数
            var arraySize = stride * Bitmap.PixelHeight;

            pixelEntity = new byte[arraySize];

            int index; // 左上隅からのバイトのインデックス

            for (int y = 0; y < Bitmap.PixelHeight; ++y)
            {
                for (int x = 0; x < Bitmap.PixelWidth; ++x)
                {
                    index = x * bytesPerPixel + y * stride;

                    var r = (byte)(((double)x / Bitmap.PixelWidth) * 255);
                    var g = (byte)(((double)y / Bitmap.PixelHeight) * 255);

                    pixelEntity[index] = 0;
                    pixelEntity[index + 1] = g;
                    pixelEntity[index + 2] = r;
                    pixelEntity[index + 3] = 255;
                }
            }
            Bitmap.WritePixels(rect, pixelEntity, stride, 0);

            this.Bitmap.Unlock();
        }

        #endregion

        #region Public Properties

        public InternalOutputs Outputs
        {
            get
            {
                return outputs;
            }

            set
            {
                outputs = value;
            }
        }

        #endregion

        #region Public Methods

        public UVNodeViewModel() : base("UV")
        {
            Initialize();
        }

        public override void Calculate()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
