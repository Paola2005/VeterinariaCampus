using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

namespace Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly VeterinariaContext _context;
    private PaisRepository _paises;
    private CiudadRepository _ciudades;
    private DeapartamentoRepository _departamentos;
    private ClienteRepository _clientes;
    private MascotaRepository _mascotas;
    private RazaRepository _razas;
    private ClienteTelefonoRepository _clientestel;
    private ClienteDireccionRepository _clientesdir;
    private ServicioRepository _servicios;

    public IPais Paises
    {
        get
        {
            if (_paises == null)
            {
                _paises = new PaisRepository(_context);
            }
            return _paises;
        }
    }

    public ICiudad Ciudades
    {
        get
        {
            if (_ciudades == null)
            {
                _ciudades = new CiudadRepository(_context);
            }
            return _ciudades;
        }
    }

    public ICliente Clientes
    {
        get
        {
            if (_clientes == null)
            {
                _clientes = new ClienteRepository(_context);
            }
            return _clientes;
        }
    }

    public IDepartamento Departamentos
    {
        get
        {
            if (_departamentos == null)
            {
                _departamentos = new DeapartamentoRepository(_context);
            }
            return _departamentos;
        }
    }

    public IMascota Mascotas
    {
        get
        {
            if (_mascotas == null)
            {
                _mascotas = new MascotaRepository(_context);
            }
            return _mascotas;
        }
    }

    public IRaza Razas
    {
        get
        {
            if (_razas == null)
            {
                _razas = new RazaRepository(_context);
            }
            return _razas;
        }
    }

    public IServicio Servicios
    {
        get
        {
            if (_servicios == null)
            {
                _servicios = new ServicioRepository(_context);
            }
            return _servicios;
        }
    }

    public IClienteTelefono ClienteTelefonos
    {
        get
        {
            if (_clientestel == null)
            {
                _clientestel = new ClienteTelefonoRepository(_context);
            }
            return _clientestel;
        }
    }

    public IClienteDireccion ClienteDirecciones  /* estas cosas se llaman en el IUnitOfWord */
    {
        get
        {
            if (_clientesdir == null)
            {
                _clientesdir = new ClienteDireccionRepository(_context);
            }
            return _clientesdir;
        }
    }

    public UnitOfWork(VeterinariaContext context)
    {
        _context = context;
    }

    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
