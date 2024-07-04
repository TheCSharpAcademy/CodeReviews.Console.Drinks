using System;
using System.Collections.Generic;
using DrinksInfo.ukpagrace.Service;
using Spectre.Console;
using DrinksInfo.ukpagrace.DTO;

namespace DrinksInfo.ukpagrace.Controller
{
    class DrinksController
    {
        DrinksService drinksService = new ();
        
        public void ShowMenu(List<MenuDto> categories)
        {
            var table = new Table().Centered();

            table.AddColumn(new TableColumn("Id").Centered());
            table.AddColumn(new TableColumn("Option").Centered());


            foreach(var category in categories)
            {

                table.AddRow(new Markup($"[blue]{category.Id}[/]"), new Markup($"[blue]{category.Name}[/]"));
            }
            AnsiConsole.Write(table);
        }

        public void ShowDrinks(List<MenuDto> categories)
        {
 
            var table = new Table().Centered();

            table.AddColumn(new TableColumn("Id").Centered());
            table.AddColumn(new TableColumn("Drink Name").Centered());


            foreach (var category in categories)
            {

                table.AddRow(new Markup($"[blue]{category.Id}[/]"), new Markup($"[blue]{category.Name}[/]"));
            }
            AnsiConsole.Write(table);


        }


        public void ShowDrinkDetails(DrinksDetailsDto details)
        {
            var detail = new Table().Centered();

            detail.AddColumn(new TableColumn("Id").Centered());
            detail.AddColumn(new TableColumn("Name").Centered());
            detail.AddColumn(new TableColumn("Category").Centered());
            detail.AddColumn(new TableColumn("Type").Centered());
            detail.AddColumn(new TableColumn("Instructions").Centered());
            detail.AddRow(
                new Markup($"[blue]{details.Id}[/]"),
                new Markup($"[blue]{details.Name}[/]"),
                new Markup($"[blue]{details.Category}[/]"),
                new Markup($"[blue]{details.Type}[/]"),
                new Markup($"[blue]{details.Instructions}[/]")
            );

            var ingredients = new Table().Centered();
            ingredients.AddColumn(new TableColumn("Ingredients").Centered());

            foreach(var item in details.Ingredients)
            {
                ingredients.AddRow(
                new Markup($"[green]{item}[/]")
                );
            }

            var measurements = new Table().Centered();
            measurements.AddColumn(new TableColumn("Measurements").Centered());

            foreach (var item in details.Measurements)
            {
                measurements.AddRow(
                new Markup($"[green]{item}[/]")
                );
            }

            var layout = new Layout("Root")
                .SplitColumns(
                    new Layout("Left"),
                    new Layout("Right")
                        .SplitRows(
                            new Layout("Top"),
                            new Layout("Bottom")));
            layout["Left"].Update(
                    detail
                    .Expand());

            layout["Top"].Update(
                    ingredients
                    .Expand());
            layout["Bottom"].Update(
                measurements
                .Expand().AsciiDoubleHeadBorder());

            AnsiConsole.Write(layout);
        }
        public void UserInput()
        {
            
        }
    }
}
