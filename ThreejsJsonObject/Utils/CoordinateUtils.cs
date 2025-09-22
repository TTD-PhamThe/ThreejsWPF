using System.Numerics;

namespace ThreejsJsonObject.Utils;

public class CoordinateUtils
{
    public static Matrix4x4 CreateWorldMatrix(Vector3 origin, Vector3 xAxis, Vector3 yAxis)
    {
        Matrix4x4 worldMatrix = Matrix4x4.Identity;

        xAxis = Vector3.Normalize(xAxis);
        yAxis = Vector3.Normalize(yAxis);
        var zAxis = Vector3.Cross(xAxis, yAxis);

        // Các vector cơ sở là 3 cột đầu tiên
        worldMatrix.M11 = xAxis.X; worldMatrix.M12 = yAxis.X; worldMatrix.M13 = zAxis.X;
        worldMatrix.M21 = xAxis.Y; worldMatrix.M22 = yAxis.Y; worldMatrix.M23 = zAxis.Y;
        worldMatrix.M31 = xAxis.Z; worldMatrix.M32 = yAxis.Z; worldMatrix.M33 = zAxis.Z;

        // Vị trí gốc là cột cuối cùng
        worldMatrix.M41 = origin.X;
        worldMatrix.M42 = origin.Y;
        worldMatrix.M43 = origin.Z;

        return worldMatrix;
    }

    public static Matrix4x4 GetTransformMatrix(
        Vector3 origin1, Vector3 x1, Vector3 y1,
        Vector3 origin2, Vector3 x2, Vector3 y2)
    {
        x1 = Vector3.Normalize(x1);
        x2 = Vector3.Normalize(x2);
        y1 = Vector3.Normalize(y1);
        y2 = Vector3.Normalize(y2);
        Matrix4x4 worldMatrix1 = CreateWorldMatrix(origin1, x1, y1);
        Matrix4x4 worldMatrix2 = CreateWorldMatrix(origin2, x2, y2);
        Matrix4x4.Invert(worldMatrix2, out Matrix4x4 inverseWorldMatrix2);
        return worldMatrix1 * inverseWorldMatrix2;
    }

    public static Matrix4x4 GetTransformGlobalToLocal(
    Vector3 oriLocal, Vector3 xAxisLocal, Vector3 yAxisLocal)
    {
        Vector3 translation = new Vector3(oriLocal.X, oriLocal.Y, oriLocal.Z);

        Vector3 axisXLocal = Vector3.Normalize(xAxisLocal);
        Vector3 axisY2Local = Vector3.Normalize(yAxisLocal);
        Vector3 axisZ2Local = Vector3.Normalize(Vector3.Cross(xAxisLocal, yAxisLocal));

        // ===== BƯỚC 2: TẠO MA TRẬN M (BIẾN ĐỔI TỪ HTĐ2 -> HTĐ1) =====
        // Ma trận này biến đổi một điểm từ không gian cục bộ của HTĐ2 về không gian của HTĐ1.
        // Các cột của ma trận là các trục và vị trí của HTĐ2.
        Matrix4x4 matrix_H2_to_H1 = new Matrix4x4(
            axisXLocal.X, axisXLocal.Y, axisXLocal.Z, 0,  // Cột 1 (trục X mới)
            axisY2Local.X, axisY2Local.Y, axisY2Local.Z, 0,  // Cột 2 (trục Y mới)
            axisZ2Local.X, axisZ2Local.Y, axisZ2Local.Z, 0,  // Cột 3 (trục Z mới)
            translation.X, translation.Y, translation.Z, 1 // Cột 4 (vị trí)
        );

        // Lưu ý: C# System.Numerics.Matrix4x4 được sắp xếp theo từng hàng (row-major)
        // nên ta cần chuyển vị (Transpose) để đúng với logic cột (column-major) thường dùng trong đồ họa.
        //matrix_H2_to_H1 = Matrix4x4.Transpose(matrix_H2_to_H1);


        // ===== BƯỚC 3: TÍNH MA TRẬN NGHỊCH ĐẢO (BIẾN ĐỔI TỪ HTĐ1 -> HTĐ2) =====
        Matrix4x4 matrix_H1_to_H2;
        bool isInvertible = Matrix4x4.Invert(matrix_H2_to_H1, out matrix_H1_to_H2);
        return isInvertible ? matrix_H1_to_H2 : Matrix4x4.Identity;
    }

}
