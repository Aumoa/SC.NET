// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.GameFramework.Pawns;

namespace SC.Engine.Runtime.GameFramework.Controllers
{
    /// <summary>
    /// 게임 역할을 수행하고 개체를 제어하는 컨트롤러입니다.
    /// </summary>
    public class AController : AActor
    {
        APawn _possessedPawn;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public AController()
        {

        }

        /// <summary>
        /// 대상 폰에 빙의합니다.
        /// </summary>
        /// <param name="inPawn"> 대상 개체를 전달합니다. </param>
        public void Possess(APawn inPawn)
        {
            if (inPawn is null)
            {
                UnPossess();
                return;
            }

            if (ReferenceEquals(_possessedPawn, inPawn))
            {
                // 새 타깃이 현재 빙의된 타깃과 일치합니다.
                return;
            }

            _possessedPawn = inPawn;
            OnPossess(inPawn);
            inPawn.PossessedBy(this);
        }

        /// <summary>
        /// 현재 빙의된 폰에서 탈출합니다.
        /// </summary>
        public void UnPossess()
        {
            if (_possessedPawn is not null)
            {
                _possessedPawn.UnPossessed();
                OnUnPossess();
                _possessedPawn = null;
            }
        }

        /// <summary>
        /// 컨트롤러가 폰에 빙의할 때 호출됩니다.
        /// </summary>
        /// <param name="inPawn"> 대상 개체가 전달됩니다. </param>
        protected virtual void OnPossess(APawn inPawn)
        {
            
        }

        /// <summary>
        /// 컨트롤러가 폰에서 탈출할 때 호출됩니다.
        /// </summary>
        protected virtual void OnUnPossess()
        {

        }

        /// <summary>
        /// 빙의된 폰을 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public APawn GetPawn()
        {
            return _possessedPawn;
        }

        /// <summary>
        /// 빙의된 폰을 가져옵니다.
        /// </summary>
        /// <typeparam name="T"> 폰 형식을 전달합니다. </typeparam>
        /// <returns> 개체가 반환됩니다. </returns>
        public T GetPawn<T>() where T : APawn
        {
            return _possessedPawn as T;
        }
    }
}
