﻿//  Copyright 2011-2012 Marc Fletcher, Matthew Dean
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
//  A commercial license of this software can also be purchased. 
//  Please see <http://www.networkcommsdotnet.com/licenses> for details.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ExamplesConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.SetBufferSize(120, 200);
                Console.SetWindowSize(120, 25);
            }
            catch (NotImplementedException) { }

            Thread.CurrentThread.Name = "MainThread";

            Console.WriteLine("Initiating NetworkCommsDotNet examples.\n");

            //All we do here is let the user choice a specific example
            Console.WriteLine("Please enter an example number:");

            //Print out the available examples
            int totalNumberOfExamples = 4;
            Console.WriteLine("1 - Basic - Message Send (Only 11 lines!)");
            Console.WriteLine("2 - Advanced - Object Send");
            Console.WriteLine("3 - Advanced - Distributed File System");
            Console.WriteLine("4 - Advanced - Remote Procedure Call");

            //Get the user choice
            Console.WriteLine("");
            int selectedExample;
            while (true)
            {
                bool parseSucces = int.TryParse(Console.ReadKey().KeyChar.ToString(), out selectedExample);
                if (parseSucces && selectedExample <= totalNumberOfExamples) break;
                Console.WriteLine("\nInvalid example choice. Please try again.");
            }

            //Clear all input so that each example can do it's own thing
            Console.Clear();

            //Run the selected example
            try
            {
                #region Run Example
                switch (selectedExample)
                {
                    case 1:
                        BasicSend.RunExample();
                        break;
                    case 2:
                        AdvancedSend.RunExample();
                        break;
                    case 3:
                        DFSTest.RunExample();
                        break;
                    case 4:
                        RPCExample.RunExample();
                        break;
                    default:
                        Console.WriteLine("Selected an invalid example number. Please restart and try again.");
                        break;
                }
                #endregion
            }
            catch (Exception ex)
            {
                NetworkCommsDotNet.NetworkComms.LogError(ex, "ExampleError");
                NetworkCommsDotNet.NetworkComms.Shutdown();
                Console.WriteLine(ex.ToString());
            }

            //When we are done we give the user a chance to see all output
            Console.WriteLine("\n\nExample has completed. Please press any key to close.");
            Console.ReadKey(true);
        }
    }
}
