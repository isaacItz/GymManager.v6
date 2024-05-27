using GymManager.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManager.ApplicationServices.EquipmentTypes
{
    public interface IEquipmentTypesAppService
    {
        Task<List<EquipmentType>> GetEquipmentTypesAsync();
        
        Task<int> AddEquipmentTypeAsync(EquipmentType equipmentType);

        Task DeleteEquipmentTypeAsync(int equipmentTypeId);

        Task<EquipmentType> GetEquipmentTypeAsync(int equipmentTypeId);

        Task EditEquipmentTypeAsync(EquipmentType equipmentType);
    }
}
