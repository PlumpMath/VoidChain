﻿using System;
using System.Collections.Generic;
using System.Linq;
using VoidChainLib.Objects;
namespace VoidChainConsole
{
    class MainClass
    {
        public static void Main(string[] args)
        {

            VoidChainLib.Cryptography.Sender sender = new VoidChainLib.Cryptography.Sender();
            sender.Run();
            Console.ReadLine();

            VoidChainLib.Blockchains.Voidchain.VoidChain chain = new VoidChainLib.Blockchains.Voidchain.VoidChain();

            chain.Initialize();

            //Console.WriteLine(x.ToArray().ToUInt32());
            //VoidChainLib.BlockChain.Block block = new VoidChainLib.BlockChain.Block();
            //var gen = block.Genesis();
           // Console.WriteLine(hex);
        }
    }
}
