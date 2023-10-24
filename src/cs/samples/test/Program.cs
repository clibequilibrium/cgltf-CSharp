using System;
using System.Threading;
using bottlenoselabs.C2CS.Runtime;
using static cgltf.PInvoke;


internal sealed class Program
{
    internal static unsafe void Main(string[] args)
    {
        CgltfOptions options = default;
        CgltfData* data;

        CString path = (CString)"Box.glb";

        CgltfResult result = CgltfParseFile(&options, path, &data);

        if (result == CgltfResult.CgltfResultSuccess)
        {
            result = CgltfLoadBuffers(&options, data, path);
        }

        if (result == CgltfResult.CgltfResultSuccess)
        {
            result = CgltfValidate(data);
        }

        Console.WriteLine($"Result: {result}");

        if (result == CgltfResult.CgltfResultSuccess)
        {
            Console.WriteLine($"Type: {data->FileType}");
            Console.WriteLine($"Meshes: {data->MeshesCount.Data}");
        }

        CgltfFree(data);
        Console.ReadKey();
    }

}