using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmerAcrossRiverSample01_2
{
    /// <summary>
    /// 遊戲狀態的列舉
    /// </summary>
    public enum GameState
    {
        Running,
        Failed,
        End
    }

    /// <summary>
    /// 每一回合的結果資料
    /// </summary>
    public class GameStageResult
    {
        public GameState State
        { get; set; }

        public string Route
        { get; set; }
        public string Message
        { get; set; }

        public GameStageResult()
        {
            Route = string.Empty;
            Message = string.Empty;
        }
    }

    public static class RoleCollectionExtension
    {
        public static bool IsGameClear(this IEnumerable<Role> roles)
        {
            return (roles.Count() == 0);
        }

        public static Role FindFarmer(this IEnumerable<Role> roles)
        {
            return roles.FirstOrDefault((x) => x.Name == RoleName.農夫);
        }

        /// <summary>
        /// Handles the game failed. (判斷 game 是否失敗)
        /// </summary>
        /// <param name="roles">The roles.</param>
        /// <returns></returns>
        public static Tuple<bool, IEnumerable<Role>> HandleGameFailed(this IEnumerable<Role> roles)
        {
            if (FindFarmer(roles) == null)
            {
                var result = roles.Where((x) => x.Food != RoleName.None && roles.Any((y) => x.Eat(y)));
                if (result.Count() > 0)
                {
                    return Tuple.Create<bool, IEnumerable<Role>>(true, result);
                }
            }

            return Tuple.Create<bool, IEnumerable<Role>>(false, null);
        }
    }
}
