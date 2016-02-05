// Copyright (C) 2013  Joey Scarr, Lukas Korsika
//
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.

using KFS.Disks;
using KFS.FileSystems;
using KFS.DataStream;
using System;
using System.Linq;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace KickassUndelete
{
    public class ConsoleCommands
    {

        public static void RestoreFiles(string dev, string restoreFolder)
        {
            try
            { Directory.CreateDirectory(restoreFolder); }
            catch { }
            if (dev.EndsWith(@"\") == true)
            {
                dev = dev.Substring(0, dev.Length - 1);
            }
            var volumes = DiskLoader.LoadLogicalVolumes();
            var volume = volumes.FirstOrDefault(x => x.ToString().Contains(dev));
            if (volume == null)
            {
                MessageBox.Show("Disk not found: " + dev);
                return;
            }
            dev = volume.ToString();

            var fs = ((IFileSystemStore)volume).FS;
            if (fs == null)
            {
                MessageBox.Show("Disk " + dev + " contains no readable FS.");
                return;
            }

            //Console.Error.WriteLine("Deleted files on " + dev);
            //Console.Error.WriteLine("=================" + new String('=', dev.Length));
            var scanner = new Scanner(dev, fs, 524288);
            scanner.ScanFinished += new EventHandler(ScanFinished);
            scanner.StartScan();
            while (!scan_finished)
            {
                Thread.Sleep(100);
            }
            var files = scanner.GetDeletedFiles();
            foreach (var file in files)
            {
                var node = file.GetFileSystemNode();
                var data = node.GetBytes(0, node.StreamLength);
                //TextWriter output = new StreamWriter(restoreFolder + file.Name);
                using (BinaryWriter b = new BinaryWriter(
                  System.IO.File.Open(restoreFolder + file.Name, FileMode.Create)))
                {
                    b.Write(data);
                    //output.Write(data, 0, data.Length);
                }

                //TextWriter tw2 = new StreamWriter(restoreFolder + file.Name);
                //tw2.WriteLine(BitConverter.ToString(data));
                //tw2.Close();
            }
        }

        public static bool scan_finished = false;
        public static void ScanFinished(object ob, EventArgs e)
        {
            scan_finished = true;
        }
    }
}
