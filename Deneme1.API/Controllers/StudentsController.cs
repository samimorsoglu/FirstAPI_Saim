using AutoMapper;
using Deneme1.Core.Model;
using Deneme1.Service.DTOs;
using Deneme1.Service.IService;
using Deneme1.Service.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Deneme1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        public StudentsController(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _studentService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<StudentDto>>(students));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            return Ok(_mapper.Map<StudentDto>(student));
        }

        [HttpPost]
        public async Task<IActionResult> Save(StudentDto studentDto)
        {
            var newStudent = await _studentService.AddAsync(_mapper.Map<Student>(studentDto));
            return Created(string.Empty, _mapper.Map<StudentDto>(newStudent));
        }

        [HttpPut]
        public IActionResult Update(StudentUpdateDto studentDto)
        {
            var student = _studentService.Update(_mapper.Map<Student>(studentDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var student = await _studentService.GetByIdAsync(id);
            _studentService.Remove(student);
            return NoContent();
        }
    }
}