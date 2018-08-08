using System;
using System.Text;
using UnityEngine;

namespace HoloToolkitExtensions.Utilities
{
    public static class TextUtilities
    {
        /// <summary>
        /// Wraps text in a mesh to a certain width.
        /// Nicked and adapted from https://answers.unity.com/questions/223906/textmesh-wordwrap.html
        /// </summary>
        /// <param name="mesh"></param>
        /// <param name="maxLength"></param>
        public static void WordWrap(this TextMesh mesh, float maxLength)
        {
            var oldQ = mesh.gameObject.transform.rotation;
            mesh.gameObject.transform.rotation = Quaternion.identity;
            var renderer = mesh.GetComponent<Renderer>();
            var parts = mesh.text.Split(' ');
            mesh.text = "";
            foreach (var t in parts)
            {
                var builder = new StringBuilder(mesh.text);

                mesh.text = string.Concat(mesh.text, t, " ");
                if (renderer.bounds.size.x > maxLength)
                {
                    builder.AppendFormat("{0}{1} ", Environment.NewLine, t);
                    mesh.text = builder.ToString();
                }
            }

            mesh.text = mesh.text.TrimEnd();
            mesh.gameObject.transform.rotation = oldQ;
        }
    }
}
