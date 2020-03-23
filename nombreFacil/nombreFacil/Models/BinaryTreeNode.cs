﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace nombreFacil.Models
{ //alex
    [Serializable]
    public class BinaryTreeNode
    {
        public enum NodeDirection
        {
            Left,
            Right
        }

        public BinaryTreeNode() { }


        public BinaryTreeNode Padre = null;
        public BinaryTreeNode IzqHijo = null;
        public BinaryTreeNode DerHijo = null;

        public bool BitValue;
        public int? Key { get; set; }
        public ulong Value { get; set; }

        public void AgregandoHijos(BinaryTreeNode hijoIzqNodo, BinaryTreeNode hijoDerNodo)
        {
            AgragandoHijo(hijoIzqNodo, NodeDirection.Left);
            AgragandoHijo(hijoDerNodo, NodeDirection.Right);
        }

        public void AgragandoHijo(BinaryTreeNode btn, NodeDirection nd)
        {
            btn.Padre = this;

            if (nd == NodeDirection.Left)
                this.IzqHijo = btn;
            else
                this.DerHijo = btn;
        }

        public char KeyAsChar
        {
            get
            {
                return Convert.ToChar(this.Key);
            }
        }

        public void GuardarDisco(string path)
        {
            var fit = new FileInfo(path);

            path = path.Replace(fit.Extension, ".hdef");

            Serializer.GuardarArchivoBinario<BinaryTreeNode>(path, this);
        }
    }
}
