using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class ServicioController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ServicioController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<Servicio>>> Get()
        {
            var entidades = await _unitOfWork.Servicios.GetAllAsync();
            return _mapper.Map<List<Servicio>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServicioDto>> Get(int id)
        {
            var entidad = await _unitOfWork.Servicios.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<ServicioDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Servicio>> Post(ServicioDto ServicioDto)
        {
            var entidad = _mapper.Map<Servicio>(ServicioDto);
            this._unitOfWork.Servicios.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            ServicioDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = ServicioDto.Id}, ServicioDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ServicioDto>> Put(int id, [FromBody] ServicioDto ServicioDto)
        {
            if(ServicioDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<Servicio>(ServicioDto);
            _unitOfWork.Servicios.Update(entidades);
            await _unitOfWork.SaveAsync();
            return ServicioDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.Servicios.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.Servicios.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }