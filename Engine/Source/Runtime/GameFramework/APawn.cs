// Copyright 2020-2021 Aumoa.lib. All right reserved.

using SC.Engine.Runtime.GameCore;

namespace SC.Engine.Runtime.GameFramework
{
    /// <summary>
    /// 컨트롤러에 빙의되어 역할을 수행하는 게임 오브젝트입니다.
    /// </summary>
    public class APawn : AActor
    {
        AController _myController;

        /// <summary>
        /// 개체를 초기화합니다.
        /// </summary>
        public APawn()
        {

        }

        /// <summary>
        /// 폰이 컨트롤러에 의해 빙의될 때 호출됩니다.
        /// </summary>
        /// <param name="inNewController"> 대상 컨트롤러가 전달됩니다. </param>
        protected internal virtual void PossessedBy(AController inNewController)
        {
            if (_myController is not null)
            {
                throw new ControllerException(ControllerException.ErrorId.AlreadyPossessed, $"폰이 이미 컨트롤러({_myController})에 빙의되어 있습니다.");
            }

            _myController = inNewController;
        }

        /// <summary>
        /// 폰이 컨트롤러에서 탈출할 때 호출됩니다.
        /// </summary>
        protected internal virtual void UnPossessed()
        {
            _myController = null;
        }

        /// <summary>
        /// 빙의된 컨트롤러를 가져옵니다.
        /// </summary>
        /// <returns> 개체가 반환됩니다. </returns>
        public AController GetController()
        {
            return _myController;
        }

        /// <summary>
        /// 빙의된 컨트롤러를 가져옵니다.
        /// </summary>
        /// <typeparam name="T"> 컨트롤러 형식을 전달합니다. </typeparam>
        /// <returns> 개체가 반환됩니다. </returns>
        public T GetController<T>() where T : AController
        {
            return GetController() as T;
        }
    }
}
