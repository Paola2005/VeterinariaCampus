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
public class ClienteTelefonoController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClienteTelefonoController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClienteTelefono>>> Get()
        {
            var entidades = await _unitOfWork.ClienteTelefonos.GetAllAsync();
            return _mapper.Map<List<ClienteTelefono>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteTelefonoDto>> Get(int id)
        {
            var entidad = await _unitOfWork.ClienteTelefonos.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<ClienteTelefonoDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteTelefono>> Post(ClienteTelefonoDto ClienteTelefonoDto)
        {
            var entidad = _mapper.Map<ClienteTelefono>(ClienteTelefonoDto);
            this._unitOfWork.ClienteTelefonos.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            ClienteTelefonoDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = ClienteTelefonoDto.Id}, ClienteTelefonoDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteTelefonoDto>> Put(int id, [FromBody] ClienteTelefonoDto ClienteTelefonoDto)
        {
            if(ClienteTelefonoDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<ClienteTelefono>(ClienteTelefonoDto);
            _unitOfWork.ClienteTelefonos.Update(entidades);
            await _unitOfWork.SaveAsync();
            return ClienteTelefonoDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.ClienteTelefonos.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.ClienteTelefonos.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }