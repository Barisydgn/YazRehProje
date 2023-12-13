using AutoMapper;
using Entities.DTO.AppointmentDto;
using Entities.DTO.EmployeeDto;
using Entities.DTO.StudentDto;
using Entities.DTO.UserDto;
using Entities.DTO.WantsDto;
using Entities.Models;

namespace YazRehProje.Ultities.Automapper
{
    public class Mapping:Profile
    {
        public Mapping()
        {
            
            #region EmployeeProfile
            CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
            CreateMap<Employee, EmployeeDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();
            #endregion


            #region StudentProfile
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Student, StudentCreateDto>().ReverseMap();
            CreateMap<Student, StudentUpdateDto>().ReverseMap();
            CreateMap<Student,StudentCreateDto2>().ReverseMap();
            #endregion

            #region WantsProfile
            CreateMap<Wants, WantsDto>().ReverseMap();
            CreateMap<Wants, WantsCreateDto>().ReverseMap();
            CreateMap<Wants, WantsUpdateDto>().ReverseMap();
            #endregion

            #region UserProfile
            CreateMap<AppUser, UserForRegistrationDto>().ReverseMap();
            #endregion

            #region AppointmentProfile
            CreateMap<Appointment, AppointmentDto>().ReverseMap(); 
            #endregion
        }
    }
}
