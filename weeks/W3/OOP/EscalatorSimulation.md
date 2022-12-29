### [⬅️ Go Back](../../../README.md)

# OOP Escalator System Homework

Assignment Link: [Patika.Dev OOP Homework #5](https://app.patika.dev/courses/oop/odev-elevator)

## ❓Question 1 :

[TR] Aşağıdaki problem ifadesine göre bir sınıf diyagramı tasarlayın.

- Nesne Yönelimli Programlamanın ilkelerini ve sınıflar arası ilişki durumlarını kullanmaya çalışın. (Encapsulation, Inheritance, Polymorphism, Abstraction)

- Kodluyoruz Sigorta Şirketi 12 katlı bir ofis binası inşa etmek ve onu en son asansör teknolojisi ile donatmak istiyor. Şirket, bina içindeki trafik akışı ihtiyaçlarını karşılayıp karşılamayacaklarını görmek için binanın asansörlerinin işlemlerini modelleyen bir yazılım simülatörü oluşturmanızı istiyor.

- Binada, her biri binanın 12 katına çıkabilecek beş asansör bulunacaktır. Her asansörün yaklaşık altı yetişkin yolcu kapasitesi vardır. Asansörler enerji tasarruflu olacak şekilde tasarlanmıştır, bu nedenle yalnızca gerektiğinde hareket ederler. Her asansörün kendi kapısı, kat gösterge ışığı ve kontrol paneli vardır. Kontrol panelinde hedef düğmeleri, kapı açma ve kapama düğmeleri ve bir acil durum sinyal düğmesi bulunur.

- Binadaki her katta, beş asansör boşluğunun her biri için bir kapı ve her kapı için bir varış zili vardır. Varış zili, asansörlerin bir kata vardığını gösterir. Her kapının üzerinde bulunan bir sinyal ışığı, asansörün gelişini ve asansörün hareket ettiği yönü gösterir. Her katta ayrıca üç set asansör çağrı düğmesi vardır.

- Bir kişi uygun çağrı düğmesine (yukarı veya aşağı) basarak bir asansörü çağırır. Bir programlayıcı, aramanın başladığı kata gitmek için beş asansörden birini görevlendirir. Asansöre girdikten sonra, bir yolcu tipik olarak bir veya daha fazla hedef düğmesine basar. Asansör kattan kata hareket ederken, asansörün içindeki bir gösterge ışığı yolcuları asansörün konumu hakkında bilgilendirir. Bir asansörün bir kata varması, dış asansör kapısının üzerindeki gösterge lambasının yakılması ve kat zilinin çalmasıyla belirtilir. Bir asansör bir katta durduğunda, her iki kapı grubu da önceden belirlenmiş bir süre boyunca otomatik olarak açılarak yolcuların asansöre girip çıkmalarına izin verir.

- Simülatör, gerçek zaman geçişini simüle etmek ve simülasyonda meydana gelen olayları zaman damgası ve günlüğe kaydetmek için bir "saat" kullanır. Simülatör tarafından yolcu oluşturmak ve her yolcu için kalkış ve varış katlarını belirlemek için rastgele bir sayı üreteci kullanılır.

## ✏️Answer 1 :

I have written mermaid syntax to generate the UML class diagram:

```c#
classDiagram
    class Passenger {
        +TimeStamp stepInTime
        +TimeStamp stepOutTime
        +void pressButton(Button b)
    }
    class TimeStamp {
        +DateTime moment
    }
    class CallPanel
    Passenger --> Button
    Passenger --> Door
    Button <|-- EmergencyButton
    Button <|-- DoorOpenButton
    Button <|-- DoorCloseButton
    Button <|-- CallUpButton
    Button <|-- CallDownButton
    Floor "1" *-- "3" CallPanel
    Floor "1" *--> "1" OuterDoor
    Building "1" *--> "5" Escalator
    Building "1" *--> "12" Floor
    Escalator *--> ControlPanel
    Escalator "1" o-- "1..6" Passenger
    Escalator "1" *--> "1" InnerDoor
    Passenger "1" *--> "2" TimeStamp
    Door "1" <|-- "1" InnerDoor
    Door "1" <|-- "1" OuterDoor
    CallPanel "1" *--> "1" CallUpButton
    CallPanel "1" *--> "1" CallDownButton
    ControlPanel -- IndicatorLight
    ControlPanel -- ArrivalBell
    ControlPanel "1" *--> "1*" DoorOpenButton
    ControlPanel "1" *--> "1*" DoorCloseButton
    ControlPanel "1" *--> "1*" EmergencyButton
    OuterDoor "1" *--> "1" IndicatorLight
    InnerDoor "1" *--> "1" IndicatorLight
    OuterDoor "1" *--> "1" ArrivalBell
```

Output:

<img src="OOP-HW5.png"/>

Enjoy 🚀 - Doruk

## My patika.dev profile:

<a href="https://app.patika.dev/kaolin"><img src="../../../assets/newPatikaLogo.svg" width=200/></a>
