using System.Numerics;
using ThreejsJsonObject.Creator.Base;
using ThreejsJsonObject.Models.Geometry.Solid;

namespace ThreejsJsonObject.Creator;

public class BraceBufferCreator : BaseObjectCreator<BufferGeometry>
{
    private double _length;
    private double _width;
    private double _thickness;
    public BraceBufferCreator(double length, double width, double thickness)
    {
        _length = length;
        _width = width;
        _thickness = thickness;
    }

    protected override BufferGeometry GenerateGeomety()
    {
        var positions = new List<double>();
        var normals = new List<double>();
        var uvs = new List<double>();

        // Định nghĩa 6 đỉnh của mặt cắt chữ L
        var p0 = (0f, 0f);
        var p1 = (_width, 0f);
        var p2 = (_width, _thickness);
        var p3 = (_thickness, _thickness);
        var p4 = (_thickness, _width);
        var p5 = (0f, _width);

        var shapeVertices = new[] { p0, p1, p2, p3, p4, p5 };

        // Z coordinates for front and back faces
        double z_front = _length / 2.0f;
        double z_back = -_length / 2.0f;

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


        void AddFace((double, double)[] vertices, double z, double[] normal, bool reverse)
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

        void AddQuad((double, double, double) v1, (double, double, double) v2, (double, double, double) v3, (double, double, double) v4, double[] normal)
        {
            AddTriangle(v1, v2, v3, normal);
            AddTriangle(v1, v3, v4, normal);
        }

        void AddTriangle((double, double, double) v1, (double, double, double) v2, (double, double, double) v3, double[] normal)
        {
            positions.AddRange([v1.Item1, v1.Item2, v1.Item3]);
            positions.AddRange([v2.Item1, v2.Item2, v2.Item3]);
            positions.AddRange([v3.Item1, v3.Item2, v3.Item3]);
            for (int i = 0; i < 3; i++) normals.AddRange(normal);
            uvs.AddRange([0f, 0f, 1f, 0f, 1f, 1f]); // UV đơn giản
        }

        return new Models.Geometry.Solid.BufferGeometry
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

    protected override Matrix4x4 PreTransformToLocation()
    {
        return Matrix4x4.Identity;
    }
}
