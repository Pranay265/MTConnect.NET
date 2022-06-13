﻿// Copyright (c) 2022 TrakHound Inc., All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

using MTConnect.Assets;
using System.Collections.Generic;
using System.Linq;

namespace MTConnect.Buffers
{
    public class MTConnectAssetQueue
    {
        private readonly int _limit;
        private readonly Dictionary<string, IAsset> _items = new Dictionary<string, IAsset>();
        private readonly object _lock = new object();


        /// <summary>
        /// Gets the current number of Items in the Buffer Queue
        /// </summary>
        public long Count
        {
            get
            {
                lock (_lock) return _items.Count;
            }
        }


        public MTConnectAssetQueue(int limit = 50000)
        {
            _limit = limit;
        }


        /// <summary>
        /// Take (n) number of IAssets and remove from the Queue
        /// </summary>
        public IEnumerable<IAsset> Take(int count = 1)
        {
            lock (_lock)
            {
                var items = _items.Take(count);
                if (!items.IsNullOrEmpty())
                {
                    var x = new List<IAsset>();

                    foreach (var item in items)
                    {
                        x.Add(item.Value);              
                    }

                    // Remove Items from Queue
                    foreach (var item in items) _items.Remove(item.Key);

                    return x;
                }
            }

            return null;
        }

        public bool Add(IAsset asset)
        {
            if (asset != null)
            {
                try
                {
                    var hash = asset.AssetId.ToMD5Hash();
                    if (!string.IsNullOrEmpty(hash))
                    {

                            lock (_lock)
                            {
                                if (_items.Count > _limit) return false;

                                if (_items.TryGetValue(hash, out var _))
                                {
                                    _items.Remove(hash);
                                    _items.Add(hash, asset);
                                    return true;
                                }
                                else
                                {
                                    _items.Add(hash, asset);
                                    return true;
                                }
                            }
                        }
                    }
                catch { }
            }

            return false;
        }   
    }
}