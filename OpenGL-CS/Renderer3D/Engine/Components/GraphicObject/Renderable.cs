﻿using System;

namespace RendererEngine
{
    public abstract class Renderable : IDisposable
    {
        public Transform transform  { get; set; }
        public Shader shader        { get; protected set; }
        public Mesh mesh            { get; protected set; }

        public unsafe void Load()
        {
            mesh.Load();
            shader.Load();
        }

        public void Render()
        {
            // Apply Transformation in the object

            { //Verificar os calculos pelo codigo do professor
                transform.Rotation.Z = System.MathF.Sin(Time.TotalElapsedSeconds) * System.MathF.PI * 1f;
                shader.SetMatrix4x4("model", transform.TransformationMatrix);
                shader.Use();
                shader.SetMatrix4x4("projection", Scene.virtualCamera.ProjectionMatrix);
            }

            mesh.Render();
        }

        public void Dispose()
        {
            mesh.Dispose();
            shader.Dispose();
        }

    }
}