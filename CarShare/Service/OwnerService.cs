using CarShare.Data.Models;
using CarShare.Data;
using CarShare.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CarShare.Service
{
    public class OwnerService
    {
        private readonly CarShareDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public OwnerService(CarShareDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> RegisterAsync(OwnerRegisterDto dto)
        {
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (existingUser != null)
            {
                throw new Exception("Email already exists.");
            }

            var user = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                UserType = UserType.Owner
            };

            user.Password = _passwordHasher.HashPassword(user, dto.Password);

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            var ownerProfile = new Owner
            {
                UserId = user.UserId
            };

            _context.OwnerProfiles.Add(ownerProfile);
            await _context.SaveChangesAsync();

            return "Registration successful. Awaiting admin approval.";
        }
        public async Task<string> CreateCarPostAsync(CarPostCreateDto dto)
        {
            var owner = await _context.OwnerProfiles.FindAsync(dto.OwnerId);
            if (owner == null)
            {
                throw new Exception("Owner not found.");
            }

            var carPost = new CarPost
            {
                Title = dto.Title,
                Description = dto.Description,
                CarType = dto.CarType,
                Model = dto.Model,
                Transmission = dto.Transmission,
                Year = dto.Year,
                Price = dto.Price,
                Location = dto.Location,
                AvailStart = dto.AvailStart,
                AvailEnd = dto.AvailEnd,
                OwnerId = dto.OwnerId
            };

            _context.CarPosts.Add(carPost);
            await _context.SaveChangesAsync();

            return "Car post created successfully.";
        }
        public async Task<List<CarPostResponseDto>> GetMyCarPostsAsync(int ownerId)
        {
            var ownerExists = await _context.OwnerProfiles.AnyAsync(o => o.Id == ownerId);
            if (!ownerExists)
                throw new Exception("Owner not found.");

            var myPosts = await _context.CarPosts
        .Include(c => c.Owner)
            .ThenInclude(o => o.User) 
        .Include(c => c.Proposals)
        .Where(c => c.OwnerId == ownerId)
        .ToListAsync();

            var postDtos = myPosts.Select(p => new CarPostResponseDto
            {
              
                Title = p.Title,
                Description = p.Description,
                CarType = p.CarType,
                Model = p.Model,
                Transmission = p.Transmission,
                Year = p.Year,
                Price = p.Price,
                Location = p.Location,
                AvailStart = p.AvailStart,
                AvailEnd = p.AvailEnd,
                OwnerId = p.OwnerId,
                OwnerName = p.Owner.User.UserName

            }).ToList();

            return postDtos;
        }
        public async Task<bool> UpdateCarPostAsync(CarPostUpdateDto dto)
        {
            var post = await _context.CarPosts.FindAsync(dto.CarId);

            if (post == null)
                return false;

            post.Title = dto.Title;
            post.Description = dto.Description;
            post.CarType = dto.CarType;
            post.Model = dto.Model;
            post.Transmission = dto.Transmission;
            post.Year = dto.Year;
            post.Price = dto.Price;
            post.Location = dto.Location;
            post.AvailStart = dto.AvailStart;
            post.AvailEnd = dto.AvailEnd;

            await _context.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteCarPostAsync(int id)
        {
            var post = await _context.CarPosts.FindAsync(id);
            if (post == null)
                return false;

            _context.CarPosts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}