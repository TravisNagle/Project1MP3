﻿////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////
//
// Project: Project1MP3
// File Name: Genre.cs
// Description: Creates the Genre enumerator
// Course: CSCI 1260-001 – Introduction to Computer Science II
// Author: Travis Nagle, naglet@etsu.edu, Department of Computing, East Tennessee State University
// Created: 08/31/2022
// Copyright: Travis Nagle, 2022
//
////////////////////////////////////////////////////////////////////////////////////////////////////////
//////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1MP3
{
    /// <summary>
    /// Creates the data type Genre with six different possible values.
    /// Assigned number values for user accessibility.
    /// </summary>
    public enum Genre
    {
        Rock = 1,
        Pop = 2,
        Jazz = 3,
        Country = 4,
        Classical = 5,
        Other = 6
    }
}
