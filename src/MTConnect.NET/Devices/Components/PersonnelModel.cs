// Copyright (c) 2022 TrakHound Inc., All Rights Reserved.

// This file is subject to the terms and conditions defined in
// file 'LICENSE', which is part of this source code package.

namespace MTConnect.Devices.Components
{
    /// <summary>
    /// Personnel is a Resource that provides information about an individual or individuals who either control, support, or otherwise interface with a piece of equipment.
    /// </summary>
    public class PersonnelComponent : Component 
    {
        public const string TypeId = "Personnel";
        public const string NameId = "per";

        public PersonnelComponent()  { Type = TypeId; }
    }
}