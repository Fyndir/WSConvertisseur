using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSConvertisseur.Controllers
{
    /// <summary>
    /// Controlleur gérant les devices
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        /// <summary>
        /// Mock de la bdd
        /// </summary>
        public List<Device> _devices { get; set; }

        /// <summary>
        /// Retourne la list de tout les devices dans la db
        /// </summary>
        /// <returns>la list des devices </returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Device>), 200)]
        public IEnumerable<Device> GetAll()
        {
            return _devices;
        }

        /// <summary>
        /// Retourne le device relatif a l'id en parametre
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response>
        /// <returns>le device correspondant</returns>
        /// 
        [HttpGet("{id}", Name = "GetDevise")]
        [ProducesResponseType(typeof(Device), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            Device device = _devices.FirstOrDefault((d) => d.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            return Ok(device);
        }

        /// <summary>
        /// Ajoute le device en parametre a la bdd
        /// </summary>
        /// <param name="device"></param>
        /// <returns>le status de la requete http</returns>
        [HttpPost]
        [ProducesResponseType(typeof(Device), 201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] Device device)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _devices.Add(device);

            return CreatedAtRoute("GetDevice", new { id = device.Id }, device);
        }

        /// <summary>
        /// Met a jour le device correspondant a l'id en param avec les données de l'object device en param
        /// </summary>
        /// <param name="id"></param>
        /// <param name="device"></param>
        /// <returns>le status http</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Device device)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != device.Id)
            {
                return BadRequest();
            }

            int index = _devices.FindIndex((d) => d.Id == id);

            if (index < 0)
            { return NotFound(); }

            _devices[index] = device;

            return NoContent();
        }

        /// <summary>
        /// Supprime l'objet en parametre de la bdd
        /// </summary>
        /// <param name="id"></param>
        /// <returns>le status http</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Device device = _devices.FirstOrDefault((d) => d.Id == id);
            if (device == null)
            {
                return NotFound();
            }
            _devices.Remove(device);

            return Ok(device);
        }

        /// <summary>
        /// Constructeur par default
        /// </summary>
        public DeviceController()
        {
            _devices = new List<Device>();
            _devices.Add(new Device()
            {
                Id = 1,
                Nom = "Dollar",
                Taux = 1.08
            });
            _devices.Add(new Device()
            {
                Id = 2,
                Nom = "Franc Suisse",
                Taux = 1.07
            });
            _devices.Add(new Device()
            {
                Id = 3,
                Nom = "Yen",
                Taux = 120
            });
        }
    }
}
