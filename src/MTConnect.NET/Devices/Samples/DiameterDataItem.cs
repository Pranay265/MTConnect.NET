// Copyright (c) 2022 TrakHound Inc., All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

namespace MTConnect.Devices.Samples
{
    /// <summary>
    /// The measured dimension of a diameter.
    /// </summary>
    public class DiameterDataItem : DataItem
    {
        public const DataItemCategory CategoryId = DataItemCategory.SAMPLE;
        public const string TypeId = "DIAMETER";
        public const string NameId = "dia";


        public DiameterDataItem()
        {
            DataItemCategory = CategoryId;
            Type = TypeId;
            Units = Devices.Units.MILLIMETER;
        }

        public DiameterDataItem(string parentId)
        {
            Id = CreateId(parentId, NameId);
            DataItemCategory = CategoryId;
            Type = TypeId;
            Name = NameId;
            Units = Devices.Units.MILLIMETER;
        }
    }
}