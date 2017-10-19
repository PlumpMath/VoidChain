﻿using System;
using System.Collections.Generic;
using VoidChainLib.Objects;

namespace VoidChainLib.BlockChain
{
	public class VoidChain
	{

		byte[] hash1 = new byte[32];
		byte[] hash2 = new byte[32];

		string timestamp; //max length 255
		string pubkey = string.Empty; //max length 132
		uint nBits = 0;
		uint pubkeyScript_len = 0;
		public uint pubkey_len { get; set; }

		uint scriptSig_len;
		public uint timestamp_len { get; set; }
		public Block Block { get; set; }
		public Transaction transaction { get; set; }

		public VoidChain(string publicKey, string timeStamp)
		{
			this.pubkey = publicKey;
			this.timestamp = timeStamp;
			Initialize();
		}

		public void Initialize()
		{
			if (pubkey.Length != 65)
				throw new VoidChainException("Invalid public key");
			if (timestamp.Length > 254 || timestamp.Length <= 0)
				throw new VoidChainException("Invalid timestamp");
			//initialize the genesis block and set the initial transaction values
			this.Block = new Block().Genesis();
			transaction = this.Block.Transaction;
			pubkey_len = (uint)pubkey.Length >> 1;
			timestamp_len = (uint)timestamp.Length;
			scriptSig_len = timestamp_len;


			//Encode pubkey to binary and prepend pubkey size, then append the OP_CHECKSIG byte         
			//transaction.pubkeyScript = ((pubkey_len + 2)*sizeof(byte)).ToByte();

			//transaction->pubkeyScript[0] = 0x41; // A public key is 32 bytes X coordinate, 
			//32 bytes Y coordinate and one byte 0x04, so 65 bytes i.e 0x41 in Hex.
			transaction.pubkeyScript.Add((byte)0x41);
            pubkey_len += 1;
            pubkeyScript_len = (uint)pubkey.Length;  //hex2bin(transaction.pubkeyScript + 1, pubkey, pubkey_len);
            //Goes after the pubkeyScript is filled out
            transaction.pubkeyScript[(int)pubkeyScript_len++] = Block.OP_CHECKSIG.ToByte();

			//pubkeyScript_len = transaction
			//transaction.pubkeyScript = new byte[]();

			//transaction.pubkeyScript[pubkey_len++] = Block.OP_CHECKSIG.ToByte();

			//transaction.pubkeyScript = malloc((pubkey_len+2)*sizeof(uint8_t));

		}

        private uint hex2bin(List<byte> p, string pubkey, uint pubkey_len)
        {
            int ret = 0;
            uint retlen = len;
        }

        //hex2bin(transaction->pubkeyScript+1, pubkey, pubkey_len);
        //returns a size

        public void Execute()
		{

		}
	}
}