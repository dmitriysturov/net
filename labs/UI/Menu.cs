using System;
using System.Collections.Generic;
using System.Data;
using PcTechs.models;
using PcTechs.services;
using PcTechs.Interfaces;

namespace PcTechs.UI
{
    public class Menu
    {
        private static List<Computer> computerBuilds = new List<Computer>();

        public static void DefaultMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Главное меню:");
                Console.WriteLine("1. Посмотреть сборки (добавить/удалить/посмотреть)");
                Console.WriteLine("2. Редактор деталей (посмотреть/добавить/удалить детали)");
                Console.WriteLine("3. Создать новую сборку");  
                Console.WriteLine("4. Выход");
                Console.Write("Выберите опцию: ");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ManageBuilds();
                        break;
                    case "2":
                        ManageComponents();
                        break;
                    case "3":
                        CreateNewBuild();  
                        break;
                    case "4":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор. Попробуйте снова.");
                        break;
                }
            }
        }


        public static void ManageBuilds()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("Управление сборками:");
                for (int i = 0; i < computerBuilds.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {computerBuilds[i].Name}");
                }

                Console.WriteLine("\nОпции:");
                Console.WriteLine("1. Добавить детали в сборку");
                Console.WriteLine("2. Удалить сборку");
                Console.WriteLine("3. Посмотреть сборку");
                Console.WriteLine("4. Вернуться в главное меню");
                Console.Write("Выберите опцию: ");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddComponentsToBuild();
                        break;
                    case "2":
                        RemoveBuild();
                        break;
                    case "3":
                        ViewBuild();
                        break;
                    case "4":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор. Попробуйте снова.");
                        break;
                }
            }
        }



        public static void CreateNewBuild()
        {
            Console.Write("Введите название новой сборки: ");
            string? buildName = Console.ReadLine();

            var newBuild = new Computer(buildName);
            computerBuilds.Add(newBuild);
            Console.WriteLine($"Сборка {buildName} создана.");
            Console.ReadKey();
        }


        public static void AddComponentsToBuild()
        {
            if (computerBuilds.Count == 0)
            {
                Console.WriteLine("Нет доступных сборок. Сначала создайте сборку.");
                Console.ReadKey();
                return;
            }


            Console.WriteLine("Выберите сборку для добавления компонентов:");
            for (int i = 0; i < computerBuilds.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {computerBuilds[i].Name}");
            }

            int buildIndex;
            if (!int.TryParse(Console.ReadLine(), out buildIndex) || buildIndex < 1 || buildIndex > computerBuilds.Count)
            {
                Console.WriteLine("Неверный выбор сборки.");
                Console.ReadKey();
                return;
            }

            var selectedBuild = computerBuilds[buildIndex - 1];


            Console.Clear();
            Console.WriteLine("Выберите тип компонента для добавления:");
            Console.WriteLine("1. Материнская плата");
            Console.WriteLine("2. Процессор");
            Console.WriteLine("3. Оперативная память");
            Console.WriteLine("4. Видеокарта");
            Console.WriteLine("5. Накопитель");
            Console.WriteLine("6. Блок питания");
            Console.WriteLine("7. Система охлаждения");
            Console.WriteLine("8. Корпус");
            Console.WriteLine("9. Монитор");

            string? componentTypeChoice = Console.ReadLine();
            string? componentType = componentTypeChoice switch
            {
                "1" => "Материнская плата",
                "2" => "Процессор",
                "3" => "Оперативная память",
                "4" => "Видеокарта",
                "5" => "Накопитель",
                "6" => "Блок питания",
                "7" => "Система охлаждения",
                "8" => "Корпус",
                "9" => "Монитор",
                _ => null
            };

            if (componentType == null)
            {
                Console.WriteLine("Неверный выбор типа компонента.");
                Console.ReadKey();
                return;
            }


            var availableComponents = ComponentsBank.GetComponentsByType(componentType);
            if (availableComponents == null || availableComponents.Count == 0)
            {
                Console.WriteLine($"Нет доступных компонентов типа {componentType}.");
                Console.ReadKey();
                return;
            }


            Console.WriteLine($"\nДоступные {componentType}:");
            for (int i = 0; i < availableComponents.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {availableComponents[i].Name} - {availableComponents[i].Cost} руб.");
            }

            Console.Write("Введите номер компонента для добавления: ");
            int componentIndex;
            if (!int.TryParse(Console.ReadLine(), out componentIndex) || componentIndex < 1 || componentIndex > availableComponents.Count)
            {
                Console.WriteLine("Неверный выбор компонента.");
                Console.ReadKey();
                return;
            }


            var selectedComponent = availableComponents[componentIndex - 1];
            selectedBuild.AddComponent(selectedComponent);

            Console.WriteLine($"{selectedComponent.Name} добавлен в сборку {selectedBuild.Name}.");
            Console.ReadKey();
        }



        public static void RemoveBuild()
        {
            Console.Write("Введите номер сборки для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= computerBuilds.Count)
            {
                Console.WriteLine($"Сборка {computerBuilds[index - 1].Name} удалена.");
                computerBuilds.RemoveAt(index - 1);
            }
            else
            {
                Console.WriteLine("Неверный номер.");
            }
            Console.ReadKey();
        }


        public static void ViewBuild()
        {
            if (computerBuilds.Count == 0)
            {
                Console.WriteLine("Нет доступных сборок.");
                Console.ReadKey();
                return;
            }


            Console.WriteLine("Выберите сборку для просмотра:");
            for (int i = 0; i < computerBuilds.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {computerBuilds[i].Name}");
            }

            int buildIndex;
            if (!int.TryParse(Console.ReadLine(), out buildIndex) || buildIndex < 1 || buildIndex > computerBuilds.Count)
            {
                Console.WriteLine("Неверный выбор сборки.");
                Console.ReadKey();
                return;
            }

            var selectedBuild = computerBuilds[buildIndex - 1];

            
            Console.Clear();
            selectedBuild.ShowComponents();

            Console.ReadKey();
        }



        
        public static void ManageComponents()
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                Console.WriteLine("Редактор деталей:");
                Console.WriteLine("1. Посмотреть все детали");
                Console.WriteLine("2. Добавить новую деталь");
                Console.WriteLine("3. Удалить деталь");
                Console.WriteLine("4. Сортировка компонентов");
                Console.WriteLine("5. Вернуться в главное меню");
                Console.Write("Выберите опцию: ");

                string? choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        ComponentsBank.DisplayAvailableComponents();
                        Console.ReadKey();
                        break;
                    case "2":
                        AddComponent();
                        break;
                    case "3":
                        RemoveComponent();
                        break;
                    case "4":
                        SortComponentsMenu();
                        break;
                    case "5":
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор. Попробуйте снова.");
                        break;
                }
            }
        }


        public static void AddComponent()
        {
            Console.Clear();
            Console.WriteLine("Выберите компонент, который хотите добавить: ");
            Console.WriteLine("1. Материнская плата");
            Console.WriteLine("2. Видеокарта");
            Console.WriteLine("3. Процессор");
            Console.WriteLine("4. Оперативная память");
            Console.WriteLine("5. Накопитель");
            Console.WriteLine("6. Блок питания");
            Console.WriteLine("7. Охлаждение");
            Console.WriteLine("8. Корпус");
            Console.WriteLine("9. Монитор");

            Console.Write("Введите номер компонента: ");
            string? choice = Console.ReadLine();

            Component? newComponent = null;
            string? componentType = null;

            switch (choice)
            {
                case "1":
                    componentType = "Материнская плата";
                    newComponent = CreateMotherboard();
                    break;

                case "2":
                    componentType = "Видеокарта";
                    newComponent = CreateGPU();
                    break;

                case "3":
                    componentType = "Процессор";
                    newComponent = CreateCPU();
                    break;

                case "4":
                    componentType = "Оперативная память";
                    newComponent = CreateRAM();
                    break;

                case "5":
                    componentType = "Накопитель";
                    newComponent = CreateStorage();
                    break;

                case "6":
                    componentType = "Блок питания";
                    newComponent = CreatePowerSupply();
                    break;

                case "7":
                    componentType = "Охлаждение";
                    newComponent = CreateCooling();
                    break;

                case "8":
                    componentType = "Корпус";
                    newComponent = CreateComputerCase();
                    break;

                case "9":
                    componentType = "Монитор";
                    newComponent = CreateMonitor();
                    break;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }

            if (newComponent != null && componentType != null)
            {
                ComponentsBank.AddComponentToBank(newComponent);
                Console.WriteLine($"{newComponent.Name} добавлен(а) в категорию {componentType}.");
            }

            Console.ReadKey();
        }

        private static MotherBoard CreateMotherboard()
        {
            string? _Type = "Материнская плата";
            Console.Write("Введите название материнской платы: ");
            string? _Name = Console.ReadLine();
            Console.Write("Введите стоимость: ");
            int _cost = int.Parse(Console.ReadLine());
            Console.Write("Введите тип подключения (внутренний/внешний): ");
            string? _connectionType = Console.ReadLine();
            Console.Write("Введите название производителя: ");
            string? _manufactor = Console.ReadLine();
            Console.Write("Введите сокет: ");
            string? _socket = Console.ReadLine();
            Console.Write("Введите тип поддерживаемой памяти: ");
            string? _TypeOfSupportedMemory = Console.ReadLine();
            Console.Write("Введите форму-фактор (ATX, MicroATX и т.д.): ");
            string? _formFactor = Console.ReadLine();
            Console.Write("Введите Чипсет: ");
            string? _chipset = Console.ReadLine();
            Console.Write("Введите количество слотов памяти: ");
            int _memoryslots = int.Parse(Console.ReadLine());
            Console.Write("Введите PCI (float): ");
            float _PCI = float.Parse(Console.ReadLine());

            return new MotherBoard
            {
                ComponentType = _Type,
                Name = _Name,
                Cost = _cost,
                ConnectionType = _connectionType,
                Manufactor = _manufactor,
                socket = _socket,
                TypeOfSupportedMemory = _TypeOfSupportedMemory,
                FormFactor = _formFactor,
                ChipSet = _chipset,
                MemorySlots = _memoryslots,
                PCI = _PCI,
            };
        }

        private static GPU CreateGPU()
        {
            string? _Type = "Видеокарта";
            Console.Write("Введите название видеокарты: ");
            string? _Name = Console.ReadLine();
            Console.Write("Введите стоимость: ");
            int _cost = int.Parse(Console.ReadLine());
            Console.Write("Введите тип подключения (внутренний/внешний): ");
            string? _connectionType = Console.ReadLine();
            Console.Write("Введите название производителя: ");
            string? _manufactor = Console.ReadLine();
            Console.Write("Введите графический процессор: ");
            string? _graphicalProcessor = Console.ReadLine();
            Console.Write("Введите объем видеопамяти (в ГБ): ");
            int _gMemory = int.Parse(Console.ReadLine());
            Console.Write("Введите битовую шину: ");
            int _busBitRate = int.Parse(Console.ReadLine());
            Console.Write("Введите тип памяти: ");
            string? _memoryType = Console.ReadLine();
            Console.Write("Введите интерфейс подключения: ");
            string? _connectionInterface = Console.ReadLine();
            Console.Write("Введите количество поддерживаемых мониторов: ");
            int _monitorsCount = int.Parse(Console.ReadLine());

            return new GPU
            {
                ComponentType = _Type,
                Name = _Name,
                Cost = _cost,
                ConnectionType = _connectionType,
                Manufactor = _manufactor,
                GraphicalProcessor = _graphicalProcessor,
                GMemory = _gMemory,
                BusBitRate = _busBitRate,
                MemoryType = _memoryType,
                ConnectionInterface = _connectionInterface,
                MonitorsCount = _monitorsCount,
            };
        }


        private static CPU CreateCPU()
        {
            string? _Type = "Процессор";
            Console.Write("Введите название процессора: ");
            string? _Name = Console.ReadLine();
            Console.Write("Введите стоимость: ");
            int _cost = int.Parse(Console.ReadLine());
            Console.Write("Введите тип подключения (внутренний/внешний): ");
            string? _connectionType = Console.ReadLine();
            Console.Write("Введите название производителя: ");
            string? _manufactor = Console.ReadLine();
            Console.Write("Введите сокет: ");
            string? _socket = Console.ReadLine();
            Console.Write("Введите количество ядер: ");
            int _cores = int.Parse(Console.ReadLine());
            Console.Write("Есть ли встроенная графика (да/нет): ");
            bool _integratedGPU = Console.ReadLine()?.ToLower() == "да";
            Console.Write("Введите тип поддерживаемой памяти: ");
            string? _memoryType = Console.ReadLine();
            Console.Write("Введите частоту процессора (в МГц): ");
            int _frequency = int.Parse(Console.ReadLine());
            Console.Write("Введите TDP (в Вт): ");
            int _TDP = int.Parse(Console.ReadLine());

            return new CPU
            {
                ComponentType = _Type,
                Name = _Name,
                Cost = _cost,
                ConnectionType = _connectionType,
                Manufactor = _manufactor,
                socket = _socket,
                cores = _cores,
                IntegratedGPU = _integratedGPU,
                MemoryType = _memoryType,
                frequency = _frequency,
                TDP = _TDP,
            };
        }


        private static PowerSupply CreatePowerSupply()
        {
            string? _Type = "Блок питания";
            Console.Write("Введите название блока питания: ");
            string? _Name = Console.ReadLine();
            Console.Write("Введите стоимость: ");
            int _cost = int.Parse(Console.ReadLine());
            Console.Write("Введите тип подключения (внутренний/внешний): ");
            string? _connectionType = Console.ReadLine();
            Console.Write("Введите название производителя: ");
            string? _manufactor = Console.ReadLine();
            Console.Write("Введите мощность блока питания (в Вт): ");
            int _powerOutput = int.Parse(Console.ReadLine());
            Console.Write("Введите рейтинг эффективности (например, 80+ Gold): ");
            string? _efficiencyRating = Console.ReadLine();
            Console.Write("Введите форм-фактор (например, ATX): ");
            string? _formFactor = Console.ReadLine();

            return new PowerSupply
            {
                ComponentType = _Type,
                Name = _Name,
                Cost = _cost,
                ConnectionType = _connectionType,
                Manufactor = _manufactor,
                PowerOutput = _powerOutput,
                EfficiencyRating = _efficiencyRating,
                FormFactor = _formFactor,
            };
        }



        private static RAM CreateRAM()
        {
            string? _Type = "Оперативная память";
            Console.Write("Введите название оперативной памяти: ");
            string? _Name = Console.ReadLine();
            Console.Write("Введите стоимость: ");
            int _cost = int.Parse(Console.ReadLine());
            Console.Write("Введите тип подключения (внутренний/внешний): ");
            string? _connectionType = Console.ReadLine();
            Console.Write("Введите название производителя: ");
            string? _manufactor = Console.ReadLine();
            Console.Write("Введите объем памяти (в ГБ): ");
            int _volumeSize = int.Parse(Console.ReadLine());
            Console.Write("Введите частоту (в МГц): ");
            int _frequency = int.Parse(Console.ReadLine());
            Console.Write("Есть ли радиатор (да/нет): ");
            bool _radiator = Console.ReadLine()?.ToLower() == "да";
            Console.Write("Введите латентность CAS: ");
            float _casLatency = float.Parse(Console.ReadLine());
            Console.Write("Введите ранг памяти: ");
            int _rang = int.Parse(Console.ReadLine());

            return new RAM
            {
                ComponentType = _Type,
                Name = _Name,
                Cost = _cost,
                ConnectionType = _connectionType,
                Manufactor = _manufactor,
                VolumeSize = _volumeSize,
                Frequency = _frequency,
                Radiator = _radiator,
                CASLatency = _casLatency,
                Rang = _rang,
            };
        }


        private static ComputerCase CreateComputerCase()
        {
            string? _Type = "Корпус";
            Console.Write("Введите название корпуса: ");
            string? _Name = Console.ReadLine();
            Console.Write("Введите стоимость: ");
            int _cost = int.Parse(Console.ReadLine());
            Console.Write("Введите тип подключения (внутренний/внешний): ");
            string? _connectionType = Console.ReadLine();
            Console.Write("Введите название производителя: ");
            string? _manufactor = Console.ReadLine();
            Console.Write("Введите форм-фактор корпуса (ATX, MicroATX и т.д.): ");
            string? _formFactor = Console.ReadLine();
            Console.Write("Введите цвет корпуса: ");
            string? _color = Console.ReadLine();
            Console.Write("Есть ли окно в корпусе (да/нет): ");
            bool _hasWindow = Console.ReadLine()?.ToLower() == "да";
            Console.Write("Введите количество отсеков для дисков: ");
            int _numberOfDriveBays = int.Parse(Console.ReadLine());

            return new ComputerCase
            {
                ComponentType = _Type,
                Name = _Name,
                Cost = _cost,
                ConnectionType = _connectionType,
                Manufactor = _manufactor,
                FormFactor = _formFactor,
                Color = _color,
                HasWindow = _hasWindow,
                NumberOfDriveBays = _numberOfDriveBays,
            };
        }


        private static OutMonitor CreateMonitor()
        {
            string? _Type = "Монитор";
            Console.Write("Введите название монитора: ");
            string? _Name = Console.ReadLine();
            Console.Write("Введите стоимость: ");
            int _cost = int.Parse(Console.ReadLine());
            Console.Write("Введите тип подключения (внутренний/внешний): ");
            string? _connectionType = Console.ReadLine();
            Console.Write("Введите название производителя: ");
            string? _manufactor = Console.ReadLine();
            Console.Write("Введите диагональ монитора (в дюймах): ");
            int _size = int.Parse(Console.ReadLine());
            Console.Write("Введите разрешение (например, 1920x1080): ");
            string? _resolution = Console.ReadLine();
            Console.Write("Введите частоту обновления (в Гц): ");
            int _refreshRate = int.Parse(Console.ReadLine());
            Console.Write("Введите тип панели (IPS, TN и т.д.): ");
            string? _panelType = Console.ReadLine();

            return new OutMonitor
            {
                ComponentType = _Type,
                Name = _Name,
                Cost = _cost,
                ConnectionType = _connectionType,
                Manufactor = _manufactor,
                Size = _size,
                Resolution = _resolution,
                RefreshRate = _refreshRate,
                PanelType = _panelType,
            };
        }


        private static StorageDevice CreateStorage()
        {
            string? _Type = "Накопитель";
            Console.Write("Введите название накопителя: ");
            string? _Name = Console.ReadLine();
            Console.Write("Введите стоимость: ");
            int _cost = int.Parse(Console.ReadLine());
            Console.Write("Введите тип подключения (внутренний/внешний): ");
            string? _connectionType = Console.ReadLine();
            Console.Write("Введите название производителя: ");
            string? _manufactor = Console.ReadLine();
            Console.Write("Введите объем накопителя (в ГБ): ");
            int _capacity = int.Parse(Console.ReadLine());
            Console.Write("Введите тип накопителя (SSD/HDD): ");
            string? _storageType = Console.ReadLine()?.ToLower();

            if (_storageType == "ssd")
            {
                Console.Write("Введите интерфейс подключения (например, SATA, NVMe): ");
                string? _interface = Console.ReadLine();
                Console.Write("Введите тип NAND памяти (TLC, SLC и т.д.): ");
                string? _nandType = Console.ReadLine();
                Console.Write("Поддержка NVMe (да/нет): ");
                bool _supportsNVMe = Console.ReadLine()?.ToLower() == "да";

                return new SSD
                {
                    Type = _Type,
                    Name = _Name,
                    Cost = _cost,
                    ConnectionType = _connectionType,
                    Manufactor = _manufactor,
                    Capacity = _capacity,
                    Interface = _interface,
                    NANDType = _nandType,
                    SupportsNVMe = _supportsNVMe,
                };
            }
            else if (_storageType == "hdd")
            {
                Console.Write("Введите интерфейс подключения (например, SATA): ");
                string? _interface = Console.ReadLine();
                Console.Write("Введите скорость вращения (в RPM): ");
                int _rpm = int.Parse(Console.ReadLine());

                return new HDD
                {
                    Type = _Type,
                    Name = _Name,
                    Cost = _cost,
                    ConnectionType = _connectionType,
                    Manufactor = _manufactor,
                    Capacity = _capacity,
                    Interface = _interface,
                    RPM = _rpm,
                };
            }
            else
            {
                Console.WriteLine("Неверный тип накопителя. Введите либо SSD, либо HDD.");
                return null!;
            }
        }


        private static CoolingSystem CreateCooling()
        {
            string? _Type = "Система охлаждения";
            Console.Write("Введите название системы охлаждения: ");
            string? _Name = Console.ReadLine();
            Console.Write("Введите стоимость: ");
            int _cost = int.Parse(Console.ReadLine());
            Console.Write("Введите тип подключения (внутренний/внешний): ");
            string? _connectionType = Console.ReadLine();
            Console.Write("Введите название производителя: ");
            string? _manufactor = Console.ReadLine();
            Console.Write("Введите тип охлаждения (воздушное/жидкостное): ");
            string? _coolingType = Console.ReadLine()?.ToLower();

            if (_coolingType == "жидкостное")
            {
                Console.Write("Введите размер радиатора (в мм): ");
                int _radiatorSize = int.Parse(Console.ReadLine());
                Console.Write("Есть ли RGB-подсветка (да/нет): ");
                bool _hasRGB = Console.ReadLine()?.ToLower() == "да";
                Console.Write("Введите совместимые сокеты: ");
                string? _compatibleSockets = Console.ReadLine();

                return new LiquidCooling
                {
                    ComponentType = _Type,
                    Name = _Name,
                    Cost = _cost,
                    ConnectionType = _connectionType,
                    Manufactor = _manufactor,
                    CoolingType = _coolingType,
                    RadiatorSize = _radiatorSize,
                    HasRGB = _hasRGB,
                    CompatibleSockets = _compatibleSockets,
                };
            }
            else if (_coolingType == "воздушное")
            {
                Console.Write("Введите размер вентилятора (в мм): ");
                int _fanSize = int.Parse(Console.ReadLine());
                Console.Write("Есть ли RGB-подсветка (да/нет): ");
                bool _hasRGB = Console.ReadLine()?.ToLower() == "да";
                Console.Write("Введите совместимые сокеты: ");
                string? _compatibleSockets = Console.ReadLine();

                return new AirCooling
                {
                    ComponentType = _Type,
                    Name = _Name,
                    Cost = _cost,
                    ConnectionType = _connectionType,
                    Manufactor = _manufactor,
                    CoolingType = _coolingType,
                    FanSize = _fanSize,
                    HasRGB = _hasRGB,
                    CompatibleSockets = _compatibleSockets,
                };
            }
            else
            {
                Console.WriteLine("Неверный тип охлаждения. Введите либо 'воздушное', либо 'жидкостное'.");
                return null!;
            }
        }



        public static void RemoveComponent()
        {
            Console.Write("Введите тип компонента (Материнская плата, Процессор и т.д.): ");
            string? componentType = Console.ReadLine();

            var components = ComponentsBank.GetComponentsByType(componentType!);
            if (components == null || components.Count == 0)
            {
                Console.WriteLine("Нет деталей для удаления.");
                Console.ReadKey();
                return;
            }

            for (int i = 0; i < components.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {components[i].Name}");
            }

            Console.Write("Введите номер детали для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= components.Count)
            {
                Console.WriteLine($"Деталь {components[index - 1].Name} удалена.");
                components.RemoveAt(index - 1);
            }
            else
            {
                Console.WriteLine("Неверный номер.");
            }
            Console.ReadKey();
        }


        public static void SortComponentsMenu()
        {
            Console.Clear();
            Console.WriteLine("Сортировка компонентов:");
            Console.WriteLine("1. Сортировать по цене (по возрастанию)");
            Console.WriteLine("2. Сортировать по цене (по убыванию)");
            Console.WriteLine("3. Сортировать по типу (SSD/HDD)");

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    SortComponentsByPrice(ascending: true);
                    break;
                case "2":
                    SortComponentsByPrice(ascending: false);
                    break;
                case "3":
                    SortComponentsByType();
                    break;
                default:
                    Console.WriteLine("Неправильный выбор. Попробуйте снова.");
                    break;
            }

            Console.ReadKey();
        }

        public static void SortComponentsByPrice(bool ascending)
        {
            var components = ComponentsBank.GetAllComponents();

            
            components.SortComponents((x, y) =>
            {
                if (ascending)
                {
                    return x.Cost.CompareTo(y.Cost);
                }
                else
                {
                    return y.Cost.CompareTo(x.Cost);
                }
            });

           
            Console.WriteLine("Компоненты, отсортированные по цене:");
            components.ForEachComponent(component =>
            {
                Console.WriteLine($"{component.Name} - {component.Cost} руб.");
            });
        }


        public static void SortComponentsByType()
        {
            var components = ComponentsBank.GetAllComponents();

            
            components.SortComponents((x, y) =>
            {
                
                if (x is IHDD && y is ISSD)
                {
                    return -1;
                }
                else if (x is ISSD && y is IHDD)
                {
                    return 1;
                }
                return 0;
            });

            
            Console.WriteLine("Компоненты, отсортированные по типу (HDD/SSD):");
            components.ForEachComponent(component =>
            {
                if (component is HDD hdd)
                {
                    Console.WriteLine($"{hdd.Name} - HDD, {hdd.Capacity}GB, {hdd.RPM} RPM");
                }
                else if (component is SSD ssd)
                {
                    Console.WriteLine($"{ssd.Name} - SSD, {ssd.Capacity}GB, NAND Type: {ssd.NANDType}, NVMe: {ssd.SupportsNVMe}");
                }
            });
        }


    }
}
