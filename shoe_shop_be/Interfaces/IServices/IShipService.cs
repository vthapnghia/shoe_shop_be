using shoe_shop_be.DTO;
using shoe_shop_be.Entities;

namespace shoe_shop_be.Interfaces.IServices
{
    public interface IShipService
    {
        Task<ShipDto> CreateShip(ShipModel shipModel, string id); 
        Task<IEnumerable<ShipDto>> GetAllShips();
        Task<ShipDto> GetShips(string id);
        Task<ShipDto> UpdateShip(string id, ShipModel shipModel, string accountId);
        Task<bool> DeleteShip(string id, string accountId);
    }
}
