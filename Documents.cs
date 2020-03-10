using System;

namespace CompanyMailingList
{
    public  class Documents
    {
        public int Id { get; set; }
        public string Addressees { get; set; }
        public string RecipientsNNN { get; set; }
        public string CustomsPost { get; set; }
        public string NotificationType { get; set; } // Тип уведомлений
        public bool Entry { get; set; } // Вьезд
        public bool Exit { get; set; } // Выезд
        public bool CargoPlacement { get; set; } // Помещение груза на временное хранеие
        public bool Sacrifieces { get; set; } //Закрытие_транзита
        public bool ThemachineTP { get; set; } // Машина_направленна_на_тп
        public string NumberTC { get; set; } //Номер_ТС
        public bool Tyre { get; set; } //Тир
        public bool TimeEvents { get; set; } // Время события
        public string DescriptionCargo { get; set; } //Описание_груза
        public string Recipient { get; set; } //Получатель
        public bool TheconditionSeals { get; set; } //Состояние_пломб
        public bool ContentState { get; set; } //Состояние_тента
        public bool RadiationControl { get; set; } // Радиационный_контроль
        public string PhoneNumberDrive { get; set; } //Телефон_водителя
        public DateTime TimeTransmissionDocumentsDriver { get; set; } // Время передачи документов водителю
    }

}
