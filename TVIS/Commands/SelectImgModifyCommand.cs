using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Imaging;
using TVIS.MVVM.ViewModels;

namespace TVIS.Commands
{
    public class SelectImgModifyCommand : CommandBase
    {
        private readonly ModifyViewModel modifyViewModel;

        public SelectImgModifyCommand(ModifyViewModel modifyViewModel)
        {
            this.modifyViewModel = modifyViewModel;
        }

        public override void Execute(object? parameter)
        {
            var filePath = string.Empty;

            OpenFileDialog openFileDialog = new();
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "All Images|*.BMP;*.DIB;*.RLE;*.JPG;*.JPEG;*.JPE;*.JFIF;*.GIF;*.TIF;*.TIFF;*.PNG|\r\nBMP Files: (*.BMP;*.DIB;*.RLE)|*.BMP;*.DIB;*.RLE|\r\nJPEG Files: (*.JPG;*.JPEG;*.JPE;*.JFIF)|*.JPG;*.JPEG;*.JPE;*.JFIF|\r\nGIF Files: (*.GIF)|*.GIF|\r\nTIFF Files: (*.TIF;*.TIFF)|*.TIF;*.TIFF|\r\nPNG Files: (*.PNG)|*.PNG";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;
            openFileDialog.ShowDialog();
            if (!string.IsNullOrEmpty(openFileDialog.FileName))
            {
                filePath = openFileDialog.FileName;
                modifyViewModel.PersonImage = new BitmapImage(new Uri(filePath));
            }
            else
            {
                MessageBox.Show($"No images selected!",
                    "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }
    }
}
