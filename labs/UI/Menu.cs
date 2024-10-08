using System;
using System.Collections.Generic;
using System.Data;
using PcTechs.models;
using PcTechs.services;
using PcTechs.Interfaces;
using PcTechs.logs;
using PcTechs.dataspace;
using PcTechs.config;

namespace PcTechs.UI
{
    public class Menu
    {
        private static List<Computer> computerBuilds = new List<Computer>();

        public static void DefaultMenu(Logger<string> logger)
        {
            string rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.Combine(rootDirectory, "..", "..", "..");
            var configFilePath = Path.Combine(projectDirectory, "configuration", "config.json");
            var config = Configuration.LoadConfiguration(configFilePath);

            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Главное меню:");
                Console.WriteLine("1. Посмотреть сборки (добавить/удалить/посмотреть)");
                Console.WriteLine("2. Редактор деталей (посмотреть/добавить/удалить детали)");
                Console.WriteLine("3. Создать новую сборку");
                Console.WriteLine("4. Сериализация/Десериализация компонентов");
                Console.WriteLine("5. Выход");
                Console.Write("Выберите опцию: ");

                string? choice = Console.ReadLine();

                logger.Log($"Выбран пункт меню: {choice}");

                switch (choice)
                {
                    case "1":
                        ManageBuilds(logger);
                        break;
                    case "2":
                        ManageComponents(logger);
                        break;
                    case "3":
                        CreateNewBuild(logger);
                        break;
                    case "4":
                        ManageSerialization(logger, config);
                        break;
                    case "5":
                        logger.Log("Пользователь вышел из программы.");
                        exit = true;
                        break;
                    default:
                        logger.Log("Неверный выбор.");
                        Console.WriteLine("Неправильный выбор. Попробуйте снова.");
                        break;
                }
            }
        }


        public static void ManageBuilds(Logger<string> logger)
        {
            bool back = false;
            while (!back)
            {
                Console.Clear();
                logger.Log("Пользователь вошёл в управление сборками.");
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
                        AddComponentsToBuild(logger);
                        break;
                    case "2":
                        RemoveBuild(logger);
                        break;
                    case "3":
                        ViewBuild(logger);
                        break;
                    case "4":
                        logger.Log("Пользователь вернулся в основное меню.");
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Неправильный выбор. Попробуйте снова.");
                        break;
                }
            }
        }



        public static void CreateNewBuild(Logger<string> logger)
        {
            logger.Log("Пользователь создал новую сборку");
            Console.Write("Введите название новой сборки: ");
            string? buildName = Console.ReadLine();

            var newBuild = new Computer(buildName);
            computerBuilds.Add(newBuild);
            logger.Log($"Сборка {buildName} создана.");
            Console.WriteLine($"Сборка {buildName} создана.");
            Console.ReadKey();
        }


        public static void AddComponentsToBuild(Logger<string> logger)
        {
            if (computerBuilds.Count == 0)
            {
                logger.Log("Нет доступных сборок. Сначала создайте сборку.");
                Console.WriteLine("Нет доступных сборок. Сначала создайте сборку.");
                Console.ReadKey();
                return;
            }


            Console.WriteLine("Выберите сборку для добавления компонентов:");
            for (int i = 0; i < computerBuilds.Count; i++)
            {
                logger.Log($"{i + 1}. {computerBuilds[i].Name}");
                Console.WriteLine($"{i + 1}. {computerBuilds[i].Name}");
            }

            int buildIndex;
            if (!int.TryParse(Console.ReadLine(), out buildIndex) || buildIndex < 1 || buildIndex > computerBuilds.Count)
            {
                logger.Log("Неверный выбор сборки.");
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
                logger.Log("Неверный выбор типа компонента.");
                Console.WriteLine("Неверный выбор типа компонента.");
                Console.ReadKey();
                return;
            }


            var availableComponents = ComponentsBank.GetComponentsByType(componentType);
            if (availableComponents == null || availableComponents.Count == 0)
            {
                logger.Log($"Нет доступных компонентов типа {componentType}.");
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
                logger.Log("Неверный выбор компонента.");
                Console.WriteLine("Неверный выбор компонента.");
                Console.ReadKey();
                return;
            }


            var selectedComponent = availableComponents[componentIndex - 1];
            selectedBuild.AddComponent(selectedComponent, logger);

            logger.Log($"{selectedComponent.Name} добавлен в сборку {selectedBuild.Name}.");
            Console.WriteLine($"{selectedComponent.Name} добавлен в сборку {selectedBuild.Name}.");
            Console.ReadKey();
        }



        public static void RemoveBuild(Logger<string> logger)
        {
            Console.Write("Введите номер сборки для удаления: ");
            if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= computerBuilds.Count)
            {
                logger.Log($"Сборка {computerBuilds[index - 1].Name} удалена.");
                Console.WriteLine($"Сборка {computerBuilds[index - 1].Name} удалена.");
                computerBuilds.RemoveAt(index - 1);
            }
            else
            {
                logger.Log("Неверный номер.");
                Console.WriteLine("Неверный номер.");
            }
            Console.ReadKey();
        }


        public static void ViewBuild(Logger<string> logger)
        {
            if (computerBuilds.Count == 0)
            {
                logger.Log("Нет доступных сборок.");
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
                logger.Log("Неверный выбор сборки.");
                Console.WriteLine("Неверный выбор сборки.");
                Console.ReadKey();
                return;
            }

            var selectedBuild = computerBuilds[buildIndex - 1];

            
            Console.Clear();
            selectedBuild.ShowComponents();

            Console.ReadKey();
        }



        
        public static void ManageComponents(Logger<string> logger)
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
                        ComponentsBank.DisplayAvailableComponents(logger);
                        Console.ReadKey();
                        break;
                    case "2":
                        AddComponent(logger);
                        break;
                    case "3":
                        RemoveComponent(logger);
                        break;
                    case "4":
                        SortComponentsMenu(logger);
                        break;
                    case "5":
                        logger.Log("Пользователь вернулся в главное меню.");
                        back = true;
                        break;
                    default:
                        logger.Log("Неправильный выбор.");
                        Console.WriteLine("Неправильный выбор. Попробуйте снова.");
                        break;
                }
            }
        }


        public static void AddComponent(Logger<string> logger)
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
                    logger.Log("Неверный выбор.");
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }

            if (newComponent != null && componentType != null)
            {
                ComponentsBank.AddComponentToBank(newComponent);
                logger.Log($"{newComponent.Name} добавлен(а) в категорию {componentType}.");
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
                frequency = _frequency,
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



        public static void RemoveComponent(Logger<string> logger)
        {
            Console.Write("Введите тип компонента (Материнская плата, Процессор и т.д.): ");
            string? componentType = Console.ReadLine();

            var components = ComponentsBank.GetComponentsByType(componentType!);
            if (components == null || components.Count == 0)
            {
                logger.Log("Нет деталей для удаления");
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
                logger.Log($"Деталь {components[index - 1].Name} удалена.");
                Console.WriteLine($"Деталь {components[index - 1].Name} удалена.");
                components.RemoveAt(index - 1);
            }
            else
            {
                logger.Log("Неверный номер.");
                Console.WriteLine("Неверный номер.");
            }
            Console.ReadKey();
        }


        public static async Task SortComponentsMenu(Logger<string> logger)
        {
            Console.Clear();
            logger.Log("Пользователь зашёл в меню сортировки компонентов.");
            Console.WriteLine("Сортировка компонентов:");
            Console.WriteLine("1. Сортировать по цене (по возрастанию)");
            Console.WriteLine("2. Сортировать по цене (по убыванию)");
            Console.WriteLine("3. Сортировать по типу (SSD/HDD)");

            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    logger.Log("Компоненты отсортированы по цене (по возрастанию).");
                    await SortComponentsByPriceAsync(ascending: true, logger);
                    break;
                case "2":
                    logger.Log("Компоненты отсортированы по цене (по убыванию).");
                    await SortComponentsByPriceAsync(ascending: false, logger);
                    break;
                case "3":
                    logger.Log("Компоненты отсортированы по типу (SSD/HDD)");
                    await SortComponentsByTypeAsync(logger);
                    break;
                default:
                    logger.Log("Неправильный выбор.");
                    Console.WriteLine("Неправильный выбор. Попробуйте снова.");
                    break;
            }

            Console.ReadKey();
        }
        public static async Task SortComponentsByPriceAsync(bool ascending, Logger<string> logger)
        {
            var components = ComponentsBank.GetAllComponents();

            // Асинхронная сортировка компонентов
            await components.SortComponentsAsync((x, y) =>
            {
                if (ascending)
                {
                    return x.Cost.CompareTo(y.Cost);
                }
                else
                {
                    return y.Cost.CompareTo(x.Cost);
                }
            },
            count => logger.Log($"Обработано элементов: {count}"), // Логирование количества обработанных элементов
            logger);

            // Вывод отсортированных компонентов
            Console.WriteLine("Компоненты, отсортированные по цене:");
            components.ForEachComponent(component =>
            {
                Console.WriteLine($"{component.Name} - {component.Cost} руб.");
            });
        }


        public static async Task SortComponentsByTypeAsync(Logger<string> logger)
        {
            var components = ComponentsBank.GetAllComponents();

            await components.SortComponentsAsync((x, y) =>
            {
                // Сортировка по типу (HDD/SSD)
                if (x is IHDD && y is ISSD)
                {
                    return -1;
                }
                else if (x is ISSD && y is IHDD)
                {
                    return 1;
                }
                return 0;
            },
            count => logger.Log($"Обработано элементов: {count}"), // Логирование количества обработанных элементов
            logger);

            // Вывод отсортированных компонентов
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


        public static void ManageSerialization(Logger<string> logger, Configuration config)
        {
            Console.Clear();
            logger.Log("Пользователь зашел в меню сериализации/десериализации.");
            Console.WriteLine("Выберите формат для сериализации:");
            Console.WriteLine("1. JSON");
            Console.WriteLine("2. XML");

            string? choice = Console.ReadLine();
            ISerializer<List<Component>> serializer = choice switch
            {
                "1" => new JSONSerializer<List<Component>>(),
                "2" => new XMLSerializer<List<Component>>(),
                _ => null!
            };

            if (serializer == null)
            {
                logger.Log("Неверный выбор.");
                Console.WriteLine("Неверный выбор. Попробуйте снова.");
                return;
            }

            string rootDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Path.Combine(rootDirectory, "..", "..", "..");
            string directoryPath = choice switch
            {
                "1" => Path.Combine(projectDirectory, config.JsonDirectory),
                "2" => Path.Combine(projectDirectory, config.XmlDirectory),
                _ => null!
            };

            if (directoryPath == null)
            {
                logger.Log("Ошибка: Директория не найдена.");
                return;
            }

            // Создаем директорию, если она не существует
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
                logger.Log($"Создана директория: {directoryPath}");
            }

            var components = ComponentsBank.GetAllComponents();

            Console.WriteLine("1. Сохранить в файл");
            Console.WriteLine("2. Загрузить из файла");

            string? operation = Console.ReadLine();
            switch (operation)
            {
                case "1":
                    Console.Write("Введите имя файла для сохранения: ");
                    string? fileName = Console.ReadLine();
                    string savePath = Path.Combine(directoryPath, fileName);
                    components.SaveToFile(savePath, serializer);
                    logger.Log($"Коллекция компонентов сохранена в файл: {savePath}");
                    break;
                case "2":
                    Console.Write("Введите имя файла для загрузки: ");
                    string? loadFileName = Console.ReadLine();
                    string loadPath = Path.Combine(directoryPath, loadFileName);
                    components.LoadFromFile(loadPath, serializer);
                    logger.Log($"Коллекция компонентов загружена из файла: {loadPath}");

                    // Добавляем десериализованные компоненты обратно в словарь
                    foreach (var component in components)
                    {
                        if (!ComponentsBank.ContainsComponent(component))
                        {
                            ComponentsBank.AddComponentToBank(component);
                        }
                        else
                        {
                            logger.Log($"{component.Name} уже существует в банке, пропущено.");
                        }
                    }


                    logger.Log($"Компоненты добавлены в словарь.");
                    break;
                default:
                    logger.Log("Неверный выбор.");
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }




    }
}
