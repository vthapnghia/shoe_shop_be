using AutoMapper;
using shoe_shop_be.DTO;
using shoe_shop_be.Entities;
using shoe_shop_be.Errors;
using shoe_shop_be.Interfaces.IRepositories;
using shoe_shop_be.Interfaces.IServices;

namespace shoe_shop_be.Services
{
    public class ShipService : IShipService
    {
        private readonly IShipRepository _shipRepository;
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public ShipService(IShipRepository shipRepository, IAccountRepository accountRepository, IMapper mapper)
        {
            _shipRepository = shipRepository;
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        public async Task<ShipDto> CreateShip(ShipModel shipModel, string id)
        {
            var account = await _accountRepository.GetById(Guid.Parse(id));

            if (account.IsSeller == false)
            {
                throw new ApiException(401, "Unauthorized!!", "");
            }
            Ships ships = new Ships();
            ships.Description = shipModel.Description;
            ships.Price = shipModel.Price;
            ships.Type = shipModel.Type;
            await _shipRepository.Insert(ships);
            await _shipRepository.SaveChange();
            var shipDto = _mapper.Map<ShipDto>(ships);
            return shipDto;
        }

        public async Task<bool> DeleteShip(string id, string accountId)
        {
            var account = await _accountRepository.GetById(Guid.Parse(accountId));
            if (account.IsSeller == false)
            {
                throw new ApiException(401, "Unauthorized!!", "");
            }
            var ships = await _shipRepository.GetById(Guid.Parse(id));
            if(ships == null)
            {
                throw new ApiException(400, "Ship is not exist", ""); 
            }
            _shipRepository.Delete(ships);
            await _shipRepository.SaveChange();
            return true;
        }

        public async Task<IEnumerable<ShipDto>> GetAllShips()
        {
            var listShip = await _shipRepository.GetAll();
            var shipDto = _mapper.Map<IEnumerable<ShipDto>>(listShip);
            return shipDto;
        }

        public async Task<ShipDto> GetShips(string id)
        {
            var ship = await _shipRepository.GetById(Guid.Parse(id));
            if(ship == null)
            {
                throw new ApiException(400, "Ship is not exist", "");
            }
            var shipDto = _mapper.Map<ShipDto>(ship);
            return shipDto;
        }

        public async Task<ShipDto> UpdateShip(string id, ShipModel shipModel, string accountId)
        {
            var account = await _accountRepository.GetById(Guid.Parse(accountId));
            if (account.IsSeller == false)
            {
                throw new ApiException(401, "Unauthorized!!", "");
            }
            var ships = await _shipRepository.GetById(Guid.Parse(id));
            if (ships == null)
            {
                throw new ApiException(400, "Ship is not exist", "");
            }
            ships.Type = shipModel.Type;
            ships.Description = shipModel.Description;
            ships.Price = shipModel.Price;
            _shipRepository.Update(ships);
            await _shipRepository.SaveChange();
            var shipDto = _mapper.Map<ShipDto>(ships);
            return shipDto;
        }
    }
}
