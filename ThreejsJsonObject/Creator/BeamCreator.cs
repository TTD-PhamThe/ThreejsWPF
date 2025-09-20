using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ThreejsJsonObject.Models;

namespace ThreejsJsonObject.Creator
{
    public class BeamCreator
    {

        public static BoxGeometry GenerateBeamGeometry(double width, double height, double length)
        {
            return new BoxGeometry()
            {
                uuid = Guid.NewGuid().ToString(),
                width = (double)width,
                height = (double)length,
                depth = (double)height
            };
        }

        public static Child GenerateBeamObject(string name, BoxGeometry geometry, Material material, Vector3 position)
        {
            Matrix4x4 matrix = Matrix4x4.CreateTranslation(position.X, (float)(position.Y + geometry.height / 2), (float)(position.Z - geometry.depth / 2));
            return new Child()
            {
                uuid = Guid.NewGuid().ToString(),
                type = "Mesh",
                name = name,
                geometry = geometry.uuid,
                material = material.uuid,
                matrix =
                [
                    matrix.M11, matrix.M12, matrix.M13, matrix.M14,
                    matrix.M21, matrix.M22, matrix.M23, matrix.M24,
                    matrix.M31, matrix.M32, matrix.M33, matrix.M34,
                    matrix.M41, matrix.M42, matrix.M43, matrix.M44,
                ]
            };
        }
    }
}
