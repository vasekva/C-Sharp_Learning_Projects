﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CodeBlogFitness_BL.Model;
using System.Linq;

namespace CodeBlogFitness_BL.Controller.Tests
{
    [TestClass()]
    public class MealControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {

            // Arrange
            var userName = Guid.NewGuid().ToString();
            var foodName = Guid.NewGuid().ToString();
            var random = new Random();
            var userController = new UserController(userName);
            var mealController = new MealController(userController.CurrentUser);
            var food = new Food(foodName, random.Next(50, 500), random.Next(50, 500), random.Next(50, 500), random.Next(50, 500));

            // Act
            mealController.Add(food, 100);

            // Assert
            Assert.AreEqual(food.Name, mealController.Meal.Products.First().Key.Name);
        }
    }
}