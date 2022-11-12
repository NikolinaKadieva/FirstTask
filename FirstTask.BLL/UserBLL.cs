namespace FirstTask.BLL
{
    using FirstTask.DAL.Entities;
    using AutoMapper;
    using FirstTask.Shared.DTOs;

    public class UserBLL
    {
        private FirstTask.DAL.UserDAL _DAL;
        private Mapper _UserMapper;

        public UserBLL()
        {
            _DAL = new DAL.UserDAL();
            var _configUser = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>().ReverseMap());

            _UserMapper = new Mapper(_configUser);
        }
        public List<UserDTO> Get()
        {
            List<User> usersFromDB = _DAL.Get();
            List<UserDTO> usersModel = _UserMapper.Map<List<User>, List<UserDTO>>(usersFromDB);
            return usersModel;
        }

        public async Task<UserDTO> GetById(int id)
        {
            var userEntity = await _DAL.GetById(id);

            UserDTO user = _UserMapper.Map<User, UserDTO>(userEntity);
            return user;
        }

        public async Task<UserDTO> Create(UserDTO user)
        {
            User userEntity = _UserMapper.Map<UserDTO, User>(user);
            await _DAL.Create(userEntity);
            return user;
        }

        public async Task<UserDTO> Update(int id, UserDTO user)
        {
            User userEntity = _UserMapper.Map<UserDTO, User>(user);
            await _DAL.Update(id, userEntity);
            
            return user;
        }


        public async Task Delete(int id)
        {
            await _DAL.Delete(id);
        }
    }
}