﻿using System;
using System.Collections.Generic;
using VoidChainLib.Objects;

namespace VoidChainLib.Blockchains.Tinychain
{
    //https://www.youtube.com/watch?v=zVqczFZr124
    public class TinyBlock
    {
        public int Index { get; set; }
        public string MerkleRoot 
        { 
            get
            {
                return GetMerkleRoot();
            }
        }
        public DateTime Timestamp { get; set; }
        public List<TinyTransaction> Transactions { get; set; }
        public string PreviousHash { get; set; }
        public string Hash 
        { 
            get
            {
                return BlockHash();
            }
         }
        public TinyBlock()
        {
        }
        public TinyBlock(int index, DateTime timestamp, List<TinyTransaction> transactions, string previousHash = null)
        {
            if (transactions == null || transactions.Count == 0)
                throw new ArgumentNullException("transactions parameter must be set to generate a block");
            this.Index = index;
            this.Timestamp = timestamp;
            this.Transactions = transactions;
            this.PreviousHash = previousHash;
        }
        public TinyBlock(int index, DateTime timestamp, TinyTransaction transaction, string previousHash = null) : this(index, timestamp, new List<TinyTransaction>(){transaction}, previousHash )
        {
            
        }
        private string GetMerkleRoot()
        {
            return new Helpers().MerkleRoot(Transactions.GetFingerprints());
        }
        private string BlockHash()
        {
            return new Helpers().ObjectsToBytes(Index, Timestamp, Data, PreviousHash).GetSHA256AsString();
        }
    }
}
