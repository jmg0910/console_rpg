using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Text_RPG_jmg_250123
{
    class Program
    {
        public class Game
        {
            public Character Player { get; set; } //"캐릭터"클래스의 플레이어 변수 생성
            public Character Monster { get; set; } //"캐릭터"클래스의 몬스터 변수 생성

            public void Start()
            {
                Console.WriteLine("캐릭터를 선택하세요 | 1 : 검사 | 2 : 도적 | 3 : 전사 | : "); //고르는 캐릭터에 맞춰 출력되는 문구
                string choice = Console.ReadLine(); // 입력하는 변수에 따라 골라지게 만듦.
                if(choice == "1") //1번을 선택할 시에 일어날 변수
                {
                    Player = new Character("검사", 150, 25, 5); // 검사에 대한 상세 변수(이름, 체력, 공격력, 방어력)
                }
                if(choice == "2")
                {
                    Player = new Character("도적", 125, 40, 1); // 도적에 대한 상세 변수(이름, 체력, 공격력, 방어력)
                }
                else
                {
                    Player = new Character("전사", 175, 15, 10); // 전사에 대한 상세 변수(이름, 체력, 공격력, 방어력)
                }

                Monster = new Character("슬라임", 50, 10, 0); // "몬스터" 변수 슬라임 생성
                Monster = new Character("고블린", 100, 25, 5); // " 몬스터" 변수 고블린 생성
                Monster = new Character("가고일", 200, 35, 10); // "몬스터" 변수" 가고일 생성
                Console.WriteLine($"당신은 {Player.Name}을 골랐습니다."); // 위 선택한 변수에 따른 플레이어 직업 출력

            }
            public void Battle()
            {
                while (Player.Health > 0 && Monster.Health > 0)
                {
                    Player.Attack(Monster);
                    if(Monster.Health > 0)
                    {
                        Monster.Attack(Player);
                        if (Player.Health <= 0)
                        {
                            Console.WriteLine("지고 말았다");
                        }
                    }
                    else
                    {
                        Console.WriteLine("당신은 승리했다");
                    }
                }
        }

        }
        public class Character // "캐릭터" 클래스 생성
        {
            public string Name { get; set; } // 캐릭터의 이름
            public int Health { get; set; } // 캐릭터의 체력
            public int AttackP { get; set; } //캐릭터의 공격력
            public int Defense { get; set; } //캐릭터의 방어력
            public Character(string name, int health, int attackp, int defense) //캐릭터에 대한 상세 변수 작성
            {
                Name = name; // 이름 변수부여
                Health = health; //체력 변수부여
                AttackP = attackp; //공격력 변수부여
                Defense = defense; //방어력 변수부여
            }
            public void Attack(Character opponent) // 주체가 되는 캐릭터가 상대를 공격한 경우
            {
                int damage = AttackP - opponent.Defense; // 데미지는 공격력에서 상대의 방어력은 뺀만큼이다.
                damage = damage > 0 ? damage : 0; // 데미지가 0보다 작다면 데미지는 0이 된다.
                opponent.Health -= damage; // 상대의 체력은 데미지만큼 깎인다
                Console.WriteLine($"{Name}이 {opponent.Name}을 공격했습니다. {damage}의 데미지"); //주체가 상대를 공격할시 나타나는 출력문구
            }
        }

        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
            game.Battle();
            Console.WriteLine("게임오버");
            Console.ReadKey();
        }
    }
}
