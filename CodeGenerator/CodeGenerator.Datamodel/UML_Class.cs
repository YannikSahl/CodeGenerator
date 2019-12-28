﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator.Datamodel
{
    public class UML_Class : UML_BaseExtension
    {

        // Relations
        public List<UML_Class> parents { get; set; }
        public List<UML_Interface> implementedInterfaces { get; set; }


        // Constructors
        public UML_Class(string className) { 
            
            // Assign name
            this.name = className;

            // Status print
            Console.WriteLine("Class object created for: " + className);

        }

        public UML_Class(string accessModifier, string className, List<UML_Attribute> umlAttributes, List<UML_Method> umlMethods, List<UML_Class> parents, List<UML_Interface> implementedInterfaces)
        {
            this.accessModifier = accessModifier;
            this.name = className;
            this.umlAttributes = umlAttributes;
            this.umlMethods = umlMethods;
            this.parents = parents;
            this.implementedInterfaces = implementedInterfaces;
        }

    }
}
