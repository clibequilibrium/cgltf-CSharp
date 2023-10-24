# cgltf-CSharp

C# bindings for https://github.com/jkuhlmann/cgltf with native dynamic link libraries based on [`imgui-cs`](https://github.com/bottlenoselabs/imgui-cs).

## How to use

```CSharp
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
```

## Developers: Documentation

For more information on how C# bindings work, see [`C2CS`](https://github.com/lithiumtoast/c2cs), the tool that generates the bindings for `cgltf` and other C libraries.

To learn how to use `cgltf`, check out the [official readme](https://github.com/jkuhlmann/cgltf/blob/master/README.md).

## License

`cgltf-CSharp` is licensed under the MIT License (`MIT`) - see the [LICENSE file](LICENSE) for details.

`cgltf` itself is licensed under MIT license (`MIT`) - see https://github.com/jkuhlmann/cgltf/blob/master/LICENSE for more details.