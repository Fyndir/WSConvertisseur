﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WSConvertisseur.Model
{
    /// <summary>
    /// Model correspondant au device de la bdd
    /// </summary>
    public class Device
    {
        /// <summary>
        /// L'id du device
        /// </summary>
        [Required]       
        public int Id { get; set; }

        /// <summary>
        /// Le nom du device
        /// </summary>
        [Required]
        public string Nom { get; set; }

        /// <summary>
        /// Le taux de change du device
        /// </summary>
        [Required]
        public double Taux { get; set; }
        
        /// <summary>
        /// Constructeur par defaut
        /// </summary>
        public Device()
        {

        }

        /// <summary>
        /// Contructeur avec parametre de l'objet device
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nom"></param>
        /// <param name="taux"></param>
        public Device(int id , string nom , double taux)
        {
            Id = id;
            Nom = nom;
            Taux = taux;
        }

        /// <summary>
        /// Surcharge du la methode equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(Device obj)
        {
            return (this.Id == obj.Id) && (this.Nom == obj.Nom) && (this.Taux == obj.Taux);
        }
    }
}
