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
    public class PersonelsController : ControllerBase
    {
        private readonly IPersonelService _personelService;
        private readonly IMapper _mapper;
        public PersonelsController(IPersonelService personelService, IMapper mapper)
        {
            _personelService = personelService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var personels= await _personelService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<PersonelDto>>(personels));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var personel = await _personelService.GetByIdAsync(id);
            return Ok(_mapper.Map<PersonelDto>(personel));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PersonelDto personelDto)
        {
            var newPersonel = await _personelService.AddAsync(_mapper.Map<Personel>(personelDto));
            return Created(string.Empty, _mapper.Map<PersonelDto>(newPersonel));
        }

        [HttpPut]
        public IActionResult Update(PersonelUpdateDto personelDto)
        {
            var personel = _personelService.Update(_mapper.Map<Personel>(personelDto));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var personel = await _personelService.GetByIdAsync(id);
            _personelService.Remove(personel);
            return NoContent();
        }
    }
}