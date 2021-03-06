// using System;
// using System.Drawing;
//
// namespace TripleTriadCustomGenerator.DrawBorder
// {
//     public class EditImage
//     {
//         private void LockUnlockBitsExample(PaintEventArgs e)
//         {
//
//             // Create a new bitmap.
//             var bmp = new Bitmap("c:\\fakePhoto.jpg");
//
//             // Lock the bitmap's bits.  
//             var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
//             var bmpData =
//                 bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite,
//                     bmp.PixelFormat);
//
//             // Get the address of the first line.
//             var ptr = bmpData.Scan0;
//
//             // Declare an array to hold the bytes of the bitmap.
//             var bytes  = Math.Abs(bmpData.Stride) * bmp.Height;
//             var rgbValues = new byte[bytes];
//
//             // Copy the RGB values into the array.
//             System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, bytes);
//
//             // Set every third value to 255. A 24bpp bitmap will look red.  
//             for (var counter = 2; counter < rgbValues.Length; counter += 3)
//                 rgbValues[counter] = 255;
//
//             // Copy the RGB values back to the bitmap
//             System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, bytes);
//
//             // Unlock the bits.
//             bmp.UnlockBits(bmpData);
//
//             // Draw the modified image.
//             Graphics.DrawImage(bmp, 0, 150);
//         }
//     }
// }