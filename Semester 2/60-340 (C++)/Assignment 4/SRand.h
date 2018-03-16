#pragma once

#include <ctime>
#include <random>

class SRand
{
public:
	SRand()
	{ std::srand(time(nullptr)); }
};
