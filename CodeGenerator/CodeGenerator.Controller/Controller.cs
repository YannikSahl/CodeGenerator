﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonInterfaces;
using CodeGenerator.Reader;
using CodeGenerator.Datamodel;
using CodeGenerator.Generator;
using System.IO;
using System.Security.Principal;
using System.Security.AccessControl;
using Exceptions;

namespace CodeGenerator.Controller
{
    public class Controller : IController
    {
        /// <summary>
        /// Interface-Methode StartProcess(). Wenn Berechtigung auf Graphml-Datei erlaubt ist, erstellt Sie Reader
        /// und Generator, ruft deren Main-Methoden auf und gibt Pfade und Datamodell weiter.
        /// </summary>
        /// <param name="filePath_Model">Graphml-Dateipfad als string vom GUI</param>
        /// <param name="filePath_Output">Ausgabepfad als string vom GUI</param>
        /// <returns>true, wenn Berechtigung erlaubt ist</returns>
        public Exception StartProcess(string filePath_Model, string filePath_Output)
        {
            if (checkPermission(filePath_Output))
            {
                try
                {
                    Reader.Reader reader = new Reader.Reader(filePath_Model);
                    Datamodel.Datamodel datamodel = reader.getDatamodel();
                    Generator.Generator generator = new Generator.Generator(filePath_Output, datamodel);
                    generator.generateCode();
                    return null;
                }
                catch (Exceptions.DatamodelMissingContentException e)
                {
                    return e;
                }
                catch (Exceptions.DatamodelMissingInformationException e)
                {
                    return e;
                }
            }
            else
            {
                return new AccessDeniedException("No Permission to Create Files in the choosen Folder. Please check the Property Settings!");
            }
        }

        public bool checkPermission(string filePath)
        {
            //WindowsIdentity principal = WindowsIdentity.GetCurrent();
            //if (File.Exists(filePath))
            //{
            //    FileInfo fi = new FileInfo(filePath);
            //    if (fi.IsReadOnly)
            //        return false;

            //    AuthorizationRuleCollection acl = fi.GetAccessControl().GetAccessRules(true, true, typeof(SecurityIdentifier));
            //    for (int i = 0; i < acl.Count; i++)
            //    {
            //        System.Security.AccessControl.FileSystemAccessRule rule = (System.Security.AccessControl.FileSystemAccessRule) acl;
            //        if (principal.User.Equals(rule.IdentityReference))
            //        {
            //            if (System.Security.AccessControl.AccessControlType.Deny.Equals
            //            (rule.AccessControlType))
            //            {
            //                if ((((int)FileSystemRights.Write) & (int)rule.FileSystemRights) == (int)(FileSystemRights.Write))
            //                    return false;
            //            }
            //            else if (System.Security.AccessControl.AccessControlType.Allow.Equals
            //            (rule.AccessControlType))
            //            {
            //                if ((((int)FileSystemRights.Write) & (int)rule.FileSystemRights) == (int)(FileSystemRights.Write))
            //                    return true;
            //            }
            //        }
            //    }

            //}
            //else
            //{
            //    return false;
            //}
            //return false;

            return true;
        }
    }
}