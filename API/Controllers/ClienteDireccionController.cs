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
public class ClienteDireccionController: BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClienteDireccionController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ClienteDireccion>>> Get()
        {
            var entidades = await _unitOfWork.ClienteDirecciones.GetAllAsync();
            return _mapper.Map<List<ClienteDireccion>>(entidades);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteDireccionDto>> Get(int id)
        {
            var entidad = await _unitOfWork.ClienteDirecciones.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            return _mapper.Map<ClienteDireccionDto>(entidad);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ClienteDireccion>> Post(ClienteDireccionDto ClienteDireccionDto)
        {
            var entidad = _mapper.Map<ClienteDireccion>(ClienteDireccionDto);
            this._unitOfWork.ClienteDirecciones.Add(entidad);
            await _unitOfWork.SaveAsync();
            if(entidad == null)
            {
                return BadRequest();
            }
            ClienteDireccionDto.Id = entidad.Id;
            return CreatedAtAction(nameof(Post), new {id = ClienteDireccionDto.Id}, ClienteDireccionDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ClienteDireccionDto>> Put(int id, [FromBody] ClienteDireccionDto ClienteDireccionDto)
        {
            if(ClienteDireccionDto == null)
            {
                return NotFound();
            }
            var entidades = _mapper.Map<ClienteDireccion>(ClienteDireccionDto);
            _unitOfWork.ClienteDirecciones.Update(entidades);
            await _unitOfWork.SaveAsync();
            return ClienteDireccionDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var entidad = await _unitOfWork.ClienteDirecciones.GetByIdAsync(id);
            if(entidad == null)
            {
                return NotFound();
            }
            _unitOfWork.ClienteDirecciones.Remove(entidad);
            await _unitOfWork.SaveAsync();
            return NoContent();
        }
    }