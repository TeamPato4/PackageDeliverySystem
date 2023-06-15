﻿using PackageDelivery.Application.DTOs.Parameters;
using System.Collections.Generic;

namespace PackageDelivery.Application.Contracts.Interfaces.Parameters
{
    public interface IAddressApplication
    {
        AddressDTO getRecordById(int id);
        IEnumerable<AddressDTO> getRecordsList(string filter);
        AddressDTO createRecord(AddressDTO record);
        AddressDTO updateRecord(AddressDTO record);
        bool deleteRecordById(int id);
    }
}
