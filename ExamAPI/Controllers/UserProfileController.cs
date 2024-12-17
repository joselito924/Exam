using ExamDAL;
using ExamModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExamAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        IUnitOfWork _dal;
        public UserProfileController(IUnitOfWork unitOfWork)
        {
            _dal = unitOfWork;
        }
        // GET: api/<UserProfileController>
        [HttpGet]
        public IEnumerable<UserProfileDTO> GetAll()
        {
            var lst = _dal.UserProfileRepo.GetAll();
            var userLst = lst.Select(x =>
            new UserProfileDTO
            {
                id = x.UserProfileId,
                name = x.Name,
                emailAddress = x.EmailAddress,
                gender = x.Gender.Gender,
                birthDate = x.BirthDate.ToShortDateString(),
                age = x.Age,
            }).ToList();
            return userLst;
        }

        // GET api/<UserProfileController>/5
        [HttpGet("{id}")]
        public UserProfileDTO Get(int id)
        {
            var x = _dal.UserProfileRepo.Find(id);
            var user = new UserProfileDTO
            {
                id = x.UserProfileId,
                name = x.Name,
                emailAddress = x.EmailAddress,
                gender = x.Gender.Gender,
                birthDate = x.BirthDate.ToShortDateString(),
                age = x.Age,
            };
            return user;
        }

        // POST api/<UserProfileController>
        [HttpPost]
        public IActionResult Post(UserProfileDTOAddUpdate value)
        {
            var user = new tblUserProfile
            {
                Name = value.name,
                EmailAddress = value.emailAddress,
                GenderId = _dal.GenderRepo.SingleOrDefault(x => string.Equals(x.Gender, value.gender, StringComparison.OrdinalIgnoreCase)).GenderId,
                BirthDate = DateTime.Parse(value.birthDate)
            };
            _dal.UserProfileRepo.Add(user);
            _dal.Complete();
            return Ok(value);
        }

        // PUT api/<UserProfileController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, UserProfileDTOAddUpdate value)
        {
            var user = new tblUserProfile
            {
                UserProfileId = id,
                Name = value.name,
                EmailAddress = value.emailAddress,
                GenderId = _dal.GenderRepo.SingleOrDefault(x => string.Equals(x.Gender, value.gender, StringComparison.OrdinalIgnoreCase)).GenderId,
                BirthDate = DateTime.Parse(value.birthDate)
            };
            _dal.UserProfileRepo.Update(user);
            _dal.Complete();
            return Ok(value);
        }

        // DELETE api/<UserProfileController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _dal.UserProfileRepo.Find(id);
            _dal.UserProfileRepo.Delete(user);
            _dal.Complete();
            return Ok("deleted");
        }
    }
}
