using AutoMapper;
using server.DTO;
using server.Helpers;
using server.Models;
using server.Repositories;

namespace server.Services;

public class UserService(
    IUserRepository userRepository,
    IMapperBase mapper) : IUserService
{
    public async Task Create(CreateUserRequest model)
    {
        // validate
        if (await userRepository.GetByEmail(model.Email!) != null)
            throw new AppException("User with the email '" + model.Email + "' already exists");

        // map model to new user object
        var user = mapper.Map<User>(model);

        // hash password
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

        // save user
        await userRepository.Create(user);
    }

    public async Task Update(int id, UpdateRequest model)
    {
        var user = await userRepository.GetById(id);

        if (user == null)
            throw new KeyNotFoundException("User not found");

        // validate
        var emailChanged = !string.IsNullOrEmpty(model.Email) && user.Email != model.Email;
        if (emailChanged && await userRepository.GetByEmail(model.Email!) != null)
            throw new AppException("User with the email '" + model.Email + "' already exists");

        // hash password if it was entered
        if (!string.IsNullOrEmpty(model.Password))
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);

        // copy model props to user
        mapper.Map(model, user);

        // save user
        await userRepository.Update(user);
    }

    public async Task Delete(int id)
    {
        await userRepository.Delete(id);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await userRepository.GetAll();
    }

    public async Task<User> GetById(int id)
    {
        var user = await userRepository.GetById(id);

        if (user == null) throw new KeyNotFoundException("User not found");

        return user;
    }
}