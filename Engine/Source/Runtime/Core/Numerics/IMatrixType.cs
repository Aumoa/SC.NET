// Copyright 2020 Aumoa.lib. All right reserved.

namespace SC.Engine.Runtime.Core.Numerics
{
    /// <summary>
    /// 상호 변경 가능한 행렬 값에 대한 공통 함수를 제공합니다.
    /// </summary>
    public interface IMatrixType
    {
        /// <summary>
        /// 해당 인덱스에 포함된 벡터 요소를 가져오거나, 없을 경우 기본값을 반환합니다.
        /// </summary>
        /// <param name="index"> 요소 인덱스를 전달합니다. </param>
        /// <typeparam name="T"> <see cref="IVectorType"/> 인터페이스를 구현한 벡터 형식을 전달합니다. </typeparam>
        /// <returns> 인덱스에 포함된 벡터 값 또는 기본값이 반환됩니다. </returns>
        T GetComponentOrDefault<T>(int index) where T : IVectorType, new();

        /// <summary>
        /// <see cref="IMatrixType"/> 인터페이스를 구현한 행렬 값을 통해 이 개체를 초기화합니다.
        /// </summary>
        /// <typeparam name="T"> <see cref="IMatrixType"/> 인터페이스를 구현한 행렬 형식을 전달합니다. </typeparam>
        /// <param name="matrix"> 행렬 값을 전달합니다. </param>
        void Construct<T>(in T matrix) where T : IMatrixType;

        /// <summary>
        /// <see cref="IMatrixType"/> 인터페이스를 구현한 행렬 형식으로 변경합니다. 이 과정에서 데이터가 손실 또는 추가될 수 있습니다.
        /// </summary>
        /// <typeparam name="T"> <see cref="IMatrixType"/> 인터페이스를 구현한 행렬 형식을 전달합니다. </typeparam>
        /// <returns> 변환된 행렬 값이 반환됩니다. </returns>
        T Convert<T>() where T : IMatrixType, new();

        /// <summary>
        /// 해당 인덱스에 유효한 값이 있는지 검사합니다.
        /// </summary>
        /// <param name="index"> 요소 인덱스를 전달합니다. </param>
        /// <returns> 유효한 값이 있으면 true를 반환합니다. </returns>
        bool Contains(int index);

        /// <summary>
        /// 해당 인덱스에 유효한 값이 있는지 검사합니다.
        /// </summary>
        /// <param name="row"> 요소 인덱스를 전달합니다. </param>
        /// <param name="column"> 요소에서 파생된 벡터의 인덱스를 전달합니다. </param>
        /// <returns> 유효한 값이 있으면 true를 반환합니다. </returns>
        bool Contains(int row, int column);

        /// <summary>
        /// 해당 인덱스에 포함된 벡터 요소를 가져오거나, 없을 경우 기본값을 반환합니다.
        /// </summary>
        /// <param name="index"> 요소 인덱스를 전달합니다. </param>
        /// <returns> 인덱스에 포함된 벡터 값 또는 기본값이 반환됩니다. </returns>
        IVectorType this[int index] { get; }

        /// <summary>
        /// 요소의 개수를 가져옵니다.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// 행 요소의 개수를 가져옵니다. 일반적으로 <see cref="Count"/>와 동일합니다.
        /// </summary>
        int Rows { get; }

        /// <summary>
        /// 각 행에 포함된 열 요소의 개수를 가져옵니다.
        /// </summary>
        int Columns { get; }
    }
}
