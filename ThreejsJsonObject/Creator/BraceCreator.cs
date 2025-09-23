using System.Numerics;
using ThreejsJsonObject.Models;
using ThreejsJsonObject.Utils;
using static ThreejsJsonObject.Models.BufferGeometry;

namespace ThreejsJsonObject.Creator;

public class BraceCreator
{
    public static BufferGeometry GenerateLBraceGeometry(float length, float width, float thickness)
    {
        var positions = new List<float>();
        var normals = new List<float>();
        var uvs = new List<float>();

        // Định nghĩa 6 đỉnh của mặt cắt chữ L
        var p0 = (0f, 0f);
        var p1 = (width, 0f);
        var p2 = (width, thickness);
        var p3 = (thickness, thickness);
        var p4 = (thickness, width);
        var p5 = (0f, width);

        var shapeVertices = new[] { p0, p1, p2, p3, p4, p5 };

        // Z coordinates for front and back faces
        float z_front = length / 2.0f;
        float z_back = -length / 2.0f;

        // --- 1. TẠO MẶT TRƯỚC VÀ MẶT SAU ---
        // Mặt trước (2 tam giác)
        AddFace([shapeVertices[0], shapeVertices[1], shapeVertices[3], shapeVertices[5]], z_front, [0f, 0f, 1f], false);
        AddFace([shapeVertices[1], shapeVertices[2], shapeVertices[3], shapeVertices[3]], z_front, [0f, 0f, 1f], false);

        // Mặt sau (2 tam giác, đảo ngược thứ tự đỉnh)
        AddFace([shapeVertices[0], shapeVertices[5], shapeVertices[3], shapeVertices[1]], z_back, [0f, 0f, -1f], false);
        AddFace([shapeVertices[1], shapeVertices[3], shapeVertices[2], shapeVertices[2]], z_back, [0f, 0f, -1f], false);

        // --- 2. TẠO CÁC MẶT CẠNH (6 MẶT) ---
        var v_front = shapeVertices.Select(p => (p.Item1, p.Item2, z_front)).ToArray();
        var v_back = shapeVertices.Select(p => (p.Item1, p.Item2, z_back)).ToArray();

        AddQuad(v_front[0], v_back[0], v_back[1], v_front[1], [0f, -1f, 0f]); // Cạnh dưới
        AddQuad(v_front[1], v_back[1], v_back[2], v_front[2], [1f, 0f, 0f]);  // Cạnh phải
        AddQuad(v_front[2], v_back[2], v_back[3], v_front[3], [0f, 1f, 0f]);  // Cạnh trong trên
        AddQuad(v_front[3], v_back[3], v_back[4], v_front[4], [-1f, 0f, 0f]); // Cạnh trong trái
        AddQuad(v_front[4], v_back[4], v_back[5], v_front[5], [0f, 1f, 0f]);  // Cạnh trên
        AddQuad(v_front[5], v_back[5], v_back[0], v_front[0], [-1f, 0f, 0f]); // Cạnh trái


        void AddFace((float, float)[] vertices, float z, float[] normal, bool reverse)
        {
            var v1 = (vertices[0].Item1, vertices[0].Item2, z);
            var v2 = (vertices[1].Item1, vertices[1].Item2, z);
            var v3 = (vertices[2].Item1, vertices[2].Item2, z);
            var v4 = (vertices[3].Item1, vertices[3].Item2, z);

            if (reverse)
            {
                AddTriangle(v3, v2, v1, normal);
                if (vertices[3] != vertices[2]) AddTriangle(v1, v4, v3, normal);
            }
            else
            {
                AddTriangle(v1, v2, v3, normal);
                if (vertices[3] != vertices[2]) AddTriangle(v3, v4, v1, normal);
            }
        }

        void AddQuad((float, float, float) v1, (float, float, float) v2, (float, float, float) v3, (float, float, float) v4, float[] normal)
        {
            AddTriangle(v1, v2, v3, normal);
            AddTriangle(v1, v3, v4, normal);
        }

        void AddTriangle((float, float, float) v1, (float, float, float) v2, (float, float, float) v3, float[] normal)
        {
            positions.AddRange([v1.Item1, v1.Item2, v1.Item3]);
            positions.AddRange([v2.Item1, v2.Item2, v2.Item3]);
            positions.AddRange([v3.Item1, v3.Item2, v3.Item3]);
            for (int i = 0; i < 3; i++) normals.AddRange(normal);
            uvs.AddRange([0f, 0f, 1f, 0f, 1f, 1f]); // UV đơn giản
        }

        return new BufferGeometry
        {
            uuid = Guid.NewGuid().ToString(),
            data = new Data
            {
                attributes = new Attributes
                {
                    position = new Position { itemSize = 3, array = positions.ToArray() },
                    normal = new Normal { itemSize = 3, array = normals.ToArray() },
                    uv = new Uv { itemSize = 2, array = uvs.ToArray() }
                }
            }
        };
    }

    public static Child GenerateLBraceObject(string name, BufferGeometry geometry, Material material, Vector3 pstart, Vector3 pend, Vector3 yLocal)
    {
        var zLocal = pstart - pend;
        var pcenter = (pstart + pend) / 2;
        var xLocal = Vector3.Cross(yLocal, zLocal);
        Matrix4x4 matrix = CoordinateUtils.GetTransformGlobalToLocal(pcenter, xLocal, yLocal);
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
